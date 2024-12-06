# Harmoniseur

## Contexte
Notre collégue Rémi Solla, alias tonton, a chutté lourdement durant ses vacances, lors d'une partie de pèche la Sole était glissante, elle s'est débattue, Rémi est tombé. Il sera indisponible pour une durée indéterminée. Il était le seul développeur sur cette application. 

Pour être franc, on l'a décommissionné, mais lorsqu'on l'a fait, on s'est rendu compte que beaucoup de monde l'utilisaient. De plus on a appris que les utilisateurs attendent de nouvelles fonctionnalités. 
Rémi était sur le coup, on ne le savait pas. 
En plus il n'a eu le temps pousser ses modifs dans le repos. Tu es le seul qui puisse nous aider.

## Métier
L'application est capable à partir :  
- d'une #note# et d'une distance en 1/2 ton de retourner la note recherchée
- à partir d'un ensemble d'#intervalles# et d'une tonique, elle est capable de donner les notes de la #gamme#

## Compléments
Pour vous aider :

### Les notes
| 0  | 1    | 2   | 3   | 4   | 5  | 6    | 7   | 8    | 9  | 10  | 11 |
|----|------|-----|-----|-----|----|------|-----|------|----|-----|----|
| Do | Do#  | Ré  | Ré# | Mi  | Fa | Fa#  | Sol | Sol# | La | La# | Si |
| Do | Ré♭ | Ré  | Mi♭ | Mi  | Fa | Sil♭| Sol | La♭ | La | Si♭ | Si |

cf : 
- [les intervalles](https://www.apprendrelesolfege.com/les-intervalles)
- [les gammes](https://www.apprendrelesolfege.com/les-gammes)

### Remarques
- Pour simplifier les choses, Rémi a choisi de calculer les distances en demi-ton. Ainsi on a des distances en nombre entier.
- Il y a des tests mais on ne sait pas s'ils sont exhaustifs
- Il y a un bug, quand on recherche une note à partir d'une distance à l'octave inférieur ça ne marche pas.
  - _Do -5 ça devrait faire Sol mais à la place ça lève une exception: Out of range_

### Nouvelle fonctionnalité 
- On aurait besoin d'ajouter la possibilité d'altérer les notes :
	- dièse `♯` : distance +1
	- bémol `♭` : distance -1

La branche la plus à jour est : https://github.com/antrax2013/Harmoniseur/tree/start

# Instrumentalisation
Mise en place de l'instrumentalisation

## La couverture des tests
Pour installer et configurer la génération d'un rapport de couverture de tests :
- dans le répertoire du projet de tests lancer la commande :
  - `dotnet add package ReportGenerator --version 5.3.6`
-  à la racine du projet lancer la commande ci-dessous pour lancer les tests et générer le rapport de couverture
  - lancer les tests et analyser la couverture : `dotnet-coverage collect 'dotnet test --no-restore --verbosity normal' -f xml -o 'coverage.xml'`
  - générer un rapport html lisible : `dotnet $(UserProfile)\.nuget\packages\reportgenerator\5.3.6\tools\net6.0\ReportGenerator.dll -reports:coverage.xml -targetdir:coveragereport -reporttypes:Html_Dark`

cf : [documentation](https://reportgenerator.io/usage)


## Stryker mutator
Pour installer et configurer stryker mutator, à la racine du projet lancer les commandes ci-dessous :
- installer l'outil sur la machine de dev : `dotnet tool install -g dotnet-stryker`
- ajouter un fichier de configuration : `dotnet new tool-manifest`
- ajouter l'outil au projet : `dotnet tool install dotnet-stryker`
- restaurer les packages nuget `dotnet tool restore`
- lancer l'analyse : `dotnet stryker --reporter "html"`


cf : [documentation](https://stryker-mutator.io/docs/stryker-net/getting-started/)



# Auteur
[![build](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/cyril-cophignon-b58b5a5b/)