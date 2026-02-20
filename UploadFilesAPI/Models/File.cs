using System;
using System.Collections.Generic;

namespace UploadFilesAPI.Models;

public partial class Fileupload
{
    public int Id { get; set; }

    public byte[] FileData { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string ContentType { get; set; } = null!;
}
