using Application.ProductImages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductImages.CreateImage
{
    public class CreateProductImageCommand : CreateProductImageDto, IRequest<Unit>
    {
    }
}
