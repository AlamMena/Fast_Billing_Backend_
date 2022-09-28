using API.DbModels.Contexts;
using API.DbModels.Invoices;
using API.Dtos.Sales.Invoices;
using API.Services.Sales.Ncf;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Services.Sales.Invoices
{
    public class InvoiceService
    {
        private readonly FbContext _context;
        private readonly IMapper _mapper;
        private readonly INcfService _ncfService;
        public InvoiceService(FbContext context, IMapper mapper, INcfService ncfService)
        {
            _context = context;
            _mapper = mapper;
            _ncfService = ncfService;
        }

        private async Task<bool> ValidateInvoiceAsync(Invoice invoice)
        {
            // validation invoice type
            var invoiceTypeExists = await _context.InvoiceTypes.AnyAsync(d => d.Id == invoice.InvoiceTypeId);
            if (!invoiceTypeExists)
            {
                throw new ValidationException("The invoice type is not valid");
            }

            // validation ncf type
            var ncfTypeExists = await _context.NcfTypes.AnyAsync(d => d.Id == invoice.NcfTypeId);
            if (!invoiceTypeExists)
            {
                throw new ValidationException("The ncf type is not valid");
            }

            // validating invoice client
            var clientExists = await _context.Clients.FindAsync(invoice.ClientId);
            if (clientExists is null)
            {
                throw new ValidationException("The client is not valid");
            }

            // validate products 
            await ValidateInvoiceProductsAsync(invoice.Details);

            return true;
        }
        private async Task<bool> ValidateInvoiceProductsAsync(IEnumerable<InvoiceDetail> details)
        {
            // validating products repeated
            var productsAreRepeated = details.GroupBy(d => d.ProductId).Any(d => d.Count() > 1);
            if (productsAreRepeated)
            {
                throw new ValidationException("Details repeated");
            }

            // selecting only the field 'productid' from invoice details request
            var invoiceRequestProductsIds = details.Select(d => d.ProductId);

            // looking for products that are inside the invoice request in the database
            var products = await _context.Products
                .Where(d => invoiceRequestProductsIds.Contains(d.Id)).Select(d => d.Id).ToListAsync();

            // if the invoice doesn't contains any product that exists in the database an exception is thrown
            if (!products.Any())
            {
                throw new ValidationException("Products are not valid");
            }

            // if the invoice request contains products that dosen't exists an exception is thrown
            var allProductsExists = !invoiceRequestProductsIds.Except(products).Any();
            if (!allProductsExists)
            {
                throw new ValidationException("Products are not valid");
            }

            return true;
        }
        private async Task<bool> SetInvoiceNcf(Invoice invoice)
        {
            // ncf configuration
            var ncfResponse = await _ncfService.GetNcfAsync(invoice.NcfTypeId);
            invoice.Ncf = ncfResponse.Ncf;
            // invoice.NcfExpiration = ncfResponse.ExpirationDate;

            // invoice ncf type name 
            invoice.NcfName = await _context.NcfTypes
                .Where(d => d.Id == invoice.NcfTypeId).Select(d => d.Name).FirstAsync();

            return true;
        }
        private async Task<bool> SetProductDataToInvoiceDetailsAsync(IEnumerable<InvoiceDetail> details)
        {
            var productsIds = details.Select(d => d.ProductId);
            var products = await _context.Products.Where(d => productsIds.Contains(d.Id)).ToListAsync();

            // setting product name to the list
            details.ToList()
                .ForEach(d => d.ProductName = products.First(p => p.Id == d.ProductId).Name);

            return true;
        }
        private async Task<bool> SetClientDataAsync(Invoice invoice)
        {
            // client information
            var client = await _context.Clients.FindAsync(invoice.ClientId) 
                ?? throw new ValidationException("Client is not valid");

            // client information
            invoice.ClientName = client.Name;
            invoice.ClientEmail = client.Email;
            invoice.ClientNoIdentification = client.NoIdentification;
            invoice.ClientAddress = client.Addresses.FirstOrDefault(d => d.Main)?.Address;

            return true;
        }
        public async Task<InvoiceDto> PostInvoiceAsync(InvoiceDto request)
        {
            await _context.Database.BeginTransactionAsync();

            // mapping request values to db model
            var invoice = _mapper.Map<Invoice>(request);

            // validating the request
            await ValidateInvoiceAsync(invoice);

            // configuring ncf
            await SetInvoiceNcf(invoice);

            // getting invoice type name
            invoice.InvoiceTypeName = await _context.InvoiceTypes
                .Where(d => d.Id == invoice.NcfTypeId).Select(d => d.Name).FirstAsync();

            // setting product data
            await SetProductDataToInvoiceDetailsAsync(invoice.Details);

            // setting client data
            await SetClientDataAsync(invoice);

            // adding the invoice changes
            await _context.AddAsync(invoice);
            await _context.SaveChangesAsync();

            // building response
            var response = _mapper.Map<InvoiceDto>(invoice);

            // commiting changes
            await _context.Database.CommitTransactionAsync();

            return response;
        }
    }
}
