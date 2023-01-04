﻿namespace SGRM.Models
{
    public class Directeur
    {
        public int DirecteurId { get; set; }

        public string Name { get; set; }

        public int? DepartementId { get; set; }
        public Departement? Departement { get; set; }

        public string? IdentityUserId { get; set; }

        public override string ToString()
        {
            string s = $"Directeur[ Id : {DirecteurId}, name : {Name}, DepartementId : {DepartementId}]";
            return s;
        }
    }
}