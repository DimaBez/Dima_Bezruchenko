using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebAPI
{
    public class Root_1
    {
        public string tag { get; set; }
        public string name { get; set; }
        public string path_lower { get; set; }
        public string path_display { get; set; }
        public string id { get; set; }
        public DateTime client_modified { get; set; }
        public DateTime server_modified { get; set; }
        public string rev { get; set; }
        public int size { get; set; }
        public bool is_downloadable { get; set; }
        public string content_hash { get; set; }
    }

    public class Root_2
    {
        public Metadata metadata { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    public class FileLockInfo
    {
        public DateTime created { get; set; }
        public bool is_lockholder { get; set; }
        public string lockholder_name { get; set; }
    }
    public class Metadata
    {
        [JsonProperty(".tag")]
        public string tag { get; set; }
        public DateTime client_modified { get; set; }
        public string content_hash { get; set; }
        public FileLockInfo file_lock_info { get; set; }
        public bool has_explicit_shared_members { get; set; }
        public string id { get; set; }
        public bool is_downloadable { get; set; }
        public string name { get; set; }
        public string path_display { get; set; }
        public string path_lower { get; set; }
        public List<PropertyGroup> property_groups { get; set; }
        public string rev { get; set; }
        public DateTime server_modified { get; set; }
        public SharingInfo sharing_info { get; set; }
        public int size { get; set; }
    }
    public class PropertyGroup
    {
        public List<Field> fields { get; set; }
        public string template_id { get; set; }
    }
    public class SharingInfo
    {
        public string modified_by { get; set; }
        public string parent_shared_folder_id { get; set; }
        public bool read_only { get; set; }
    }
}
