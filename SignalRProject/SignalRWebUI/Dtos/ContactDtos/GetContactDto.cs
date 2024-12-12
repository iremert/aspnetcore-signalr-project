﻿namespace SignalRWebUI.Dtos.ContactDtos
{
    public class GetContactDto
    {
        public int ContactID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; } //mesaj görüldü vs için
        public bool Status2 { get; set; } //mesaj durum
    }
}
