﻿using System;
using TravelGuide.Models.Abstractions;

namespace TravelGuide.Models.Gallery
{
    public class GalleryLike : Like
    {
        public GalleryLike(Guid userId, Guid imageId)
        {
            this.UserId = userId;
            this.GalleryImageId = imageId;
        }

        public Guid GalleryImageId { get; set; }

        public virtual GalleryImage GalleryImage { get; set; }
    }
}