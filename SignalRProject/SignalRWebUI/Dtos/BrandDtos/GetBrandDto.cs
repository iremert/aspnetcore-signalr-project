﻿namespace SignalRWebUI.Dtos.BrandDtos
{
    public class GetBrandDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}