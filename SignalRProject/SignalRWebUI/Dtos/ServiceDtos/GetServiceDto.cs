﻿namespace SignalRWebUI.Dtos.ServiceDtos
{
    public class GetServiceDto
    {
        public int ServiceID { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
