﻿using System;
using System.Collections.Generic;
using TravelGuide.Models.Gallery;

namespace TravelGuide.Services.GalleryImages.Contracts
{
    public interface IGalleryImageService
    {
        IEnumerable<GalleryImage> GetAllGalleryImages();

        IEnumerable<GalleryImage> GetAllNotDeletedGalleryImagesOrderedByDate();

        GalleryImage GetGalleryImageById(Guid id);

        void ToggleLike(string id, Guid imageId);

        void AddComment(string id, string content, Guid imageId);

        void DeleteImage(GalleryImage image);

        void AddNewImage(string id, string title, string imageUrl);

        void DeleteComment(string commentId);
    }
}
