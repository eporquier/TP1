using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TPMoyennes;

namespace TPMoyennes
{

    //Création de la classe et initialisation de ses champs
    class Classe
    {
        public string       nomClasse;
        public List<Eleve>  eleves;
        public List<string> matieres;

        // Constructeur de la classe
        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;
            eleves    = new List<Eleve>();
            matieres  = new List<string>();
        }

        // Méthode permettant d'ajouter un élève dans la classe (ajouterEleve)
        public void ajouterEleve(string prenom, string nom)
        {
            eleves.Add(new Eleve(prenom, nom));
        }

        // Méthode permettant d'ajouter une matière étudiée par les élèves de la classe
        public void ajouterMatiere(string matiere)
        {
            matieres.Add(matiere);
        }

        // Calcul de la moyenne de la classe pour une matière
        public double moyenneMatiere(int i)
        {
            double totalMatiere = 0;

            foreach(Eleve eleve in this.eleves)
            {
                totalMatiere += eleve.moyenneMatiere(i);
            }

            double resultat = totalMatiere / eleves.Count;
            return double.Round(resultat, 2);
        }

        // Calcul de la moyenne générale de la classe
        public double moyenneGeneral()
        {
            double totalGeneral = 0;

            foreach(Eleve eleve in eleves)
            {
                totalGeneral += eleve.moyenneGeneral();
            }
            // Le résultat est retourné arondi au centième à chaque appel de de la methode par eleve.moyenneGeneral
            double resultat = totalGeneral / eleves.Count;
            return double.Round(resultat, 2);
        }
    }
}
