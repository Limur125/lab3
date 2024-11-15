﻿using System;

namespace Reservation_Service
{
    public class Hotels
    {
        public int Id { get; set; }
        public Guid HotelUid { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int? Stars { get; set; }
        public int Price { get; set; }
    }
}
