﻿namespace Catalog.Api.CustomException
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Product not found..")
        {
        }
    }

}
