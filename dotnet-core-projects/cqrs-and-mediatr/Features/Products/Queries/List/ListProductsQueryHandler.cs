﻿using cqrs_and_mediatr.Features.Products.DTOs;
using cqrs_and_mediatr.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs_and_mediatr.Features.Products.Queries.List
{
    public class ListProductsQueryHandler(AppDbContext context) : IRequestHandler<ListProductsQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(ListProductsQuery query, CancellationToken token)
        {
            return await context.Products
                .Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price))
                .ToListAsync();
        }
    }
}
