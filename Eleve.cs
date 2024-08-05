using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using TPMoyennes;

namespace TPMoyennes
{
    //Création de la classe et initialisation de ses champs
    internal class Eleve
    {
        public string prenom;
        public string nom;
        public List<Note> notes;

        // Constructeur de la classe Eleve
        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.notes = new List<Note>();
        }

        // Méthode pour ajouter une note à la liste de note de l'élève (ajouterNote)
        public void ajouterNote(Note note)
        {
            notes.Add(note);
        }

        // Méthode de calcul de la moyenne de l'élève dans la matière donnée (moyenneMatiere)
        public double moyenneMatiere(int matiere)
        {
            int nombreNotes = 0;
            double totalMatiere = 0;

            foreach (Note note in this.notes)
            {
                if (note.matiere == matiere)
                {
                    nombreNotes++;
                    totalMatiere += note.note;
                }
            }

            double resultat = totalMatiere / nombreNotes;
            // Le résultat est retourné arondi au centième à chaque appel de la méthode par élève (eleve.moyenneMatiere)
            return double.Round(resultat, 2);
        }

        // Méthode de calcul de la moyenne générale de l'élève (moyenneGeneral)
        public double moyenneGeneral()
        {
            // On parcours la liste des notes pour savoir quelles sont les matères étudiées par l'élève, à chaque fois que 
            // l'on trouve une matière nouvelle dans la liste de note on l'ajoute à la liste des matières étudiée par l'élève 
            // (matieresEleve)
            List<int> matieresEleve = new List<int>();
            foreach (Note note in notes)
            {
                if (matieresEleve.Contains(note.matiere) == false)
                {
                    matieresEleve.Add(note.matiere);
                }
            }

            // calcule la moyenne pour chaque matière puis de la moyenne des moyennes
            double totalGeneral = 0;

            foreach (int matiere in matieresEleve)
            {
                totalGeneral += moyenneMatiere(matiere);
            }
            // Le résultat est retourné arondi au centième à chaque appel de de la methode par eleve.moyenneGeneral
            double resultat = totalGeneral / matieresEleve.Count;
            return double.Round(resultat, 2);
        }
    }
}
