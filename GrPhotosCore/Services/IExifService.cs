﻿using GrPhotosCore.Domain;
using GrPhotosCore.Infrastructure;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace GrPhotosCore.Services;

public interface IExifService
{
     Task<List<string>?> GetGalleriesAsync(string filename);

     /// <summary>
     /// Return a list of exifs to show in home page
     /// </summary>
     /// <param name="filename">Json Filename</param>
     /// <returns>A list of exifs</returns>
     Task<List<Exif>?> GetHomeExifs(string filename);
}

public class ExifService : IExifService
{
    private readonly INopFileProvider _fileProvider;

    public ExifService(
        INopFileProvider fileProvider
    ) {
        _fileProvider = fileProvider;
    }

    public async Task<List<string>?> GetGalleriesAsync(string filename) {
        var exifs = await GetExifs(filename);

        var galleries = exifs?.Select(x=>x.Gallery).Distinct().ToList();

        return galleries;
    }

    /// <summary>
    /// Return a list of exifs to show in home page
    /// </summary>
    /// <param name="filename">Json Filename</param>
    /// <returns>A list of exifs</returns>
    public async Task<List<Exif>?> GetHomeExifs(string filename) {
        var exifs = await GetExifs(filename);
        var galleries = exifs?.Where(x => x.ShowToHome).ToList();

        return galleries;
    }

    private async Task<List<Exif>?>  GetExifs(string filename)
    {
        // get exifs file
        var filePathJson = _fileProvider.MapPath($"~/App_Data/{filename}.json");

        // read all data
        var jsonData = await System.IO.File.ReadAllTextAsync(filePathJson);

        // declare date time format from exif
        var jsonSettings = new JsonSerializerSettings {
            DateFormatString = "yyyy:MM:dd HH:mm:ss" //this won't help much for the 'date' only field!
        };

        // list of exifs
        var carousel = JsonConvert.DeserializeObject<List<Exif>>(jsonData, jsonSettings);

        return carousel;
    }
}