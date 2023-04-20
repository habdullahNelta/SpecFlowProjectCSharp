# Specflow BDD (cucumber) mit C# 

## **Projekt umgebung vorbereiten**
1. IDE: Das Projekt sollte am besten in Visual Studio2022 bearbeitet werden.

2. Extention: Installation der `Extention von Specflow` des Projekts in Menüliste unter Extention dann manage Extention klicken 

![SpecFlow](Readme/SpecFlow_Extention.png)

3. Dependencies: unter Dependencies im Solution Explorer Fenster mit der rechten Maustaste klicken, Menüliste erscheint, dann auf Manage NuGet Packages klicken, damit öffnet sich ein Fenster zum Hinzufügen der Dependencies.

![SpecFlow](Readme/Depends.png)


## **Aufbau des Projekts**
1. `Feature Ordner`: der besteht aus feature Datei, wo die Szenarien geschrieben werden. 

2. `Hooks Ordner`: der besteht aus folgenden Klassen:

      - Hooks1: hier ist die Logik der drivers geschrieben.
      - Ulit: Hier ist eine Methode für das Einlesen der Json-Datei programmiert, so dass der Browsertyp aus der Datei BrowserConfig.json eingestellt werden kann.

3. `Pages Ordner`: hier sind peges nach POM-Pernzip programmiert.

4. `StepDefinitions Ordner`: Hier sind die Steps der Feature implementiert.

5. `BrowserConfig Datei`: Hier wird der browser eingegeben.

## **Das Modellprojekt anwenden**

Das Projekt enthält Demo-Test, der nach dem Aufbau mit dem POM-Prinzip und ohne Fehler oder Warnungen funktioniert.

![SpecFlow](Readme/ErrorWarning.png)

1. Erstellung von feature Datei: im Solution Explorer Fenster auf Feature Ordner mit der rechten Maustaste klicken, Menüliste erscheint, dann add => New Item.. => weiter mit folgenen Bild:

![SpecFlow](Readme/featureErstellung.png)

2. Erstellung Page Klasse: nach POM-Prinzip wie folgt:

![SpecFlow](Readme/Pages.png)

3. Erstellung StepDefinitions: dies kann ganz einfach von feature Datei generiert werden.
innerhalb der feature Datei mit der rechten Maustaste klicken, Menüliste erscheint => Define Steps... dann erscheint Define Steps Fenster => create

![SpecFlow](Readme/steps.png)

der neu generierter StepDefinition Datei sieht wie folgt aus:

![SpecFlow](Readme/Stepsnew.png)

sehr wichtig es soll am Anfang driver installiert und der konstruktor auch damit der driver in dieser Klasse übernommen werden kann. sehe "LoginStepDefinitions" 



## **run im Test Explorer Fenster**
zum öffnen `Test Explorer` Fenster klicken Strg+E+T oder von der menüliste von Test 
Ausführen des Tests wie folgt:

![SpecFlow](Readme/runnormal.png)

### **run in CMD**
der test kann mit dem Befehl `dotnet test --filter Category=tag` ausgeführt werden.

![SpecFlow](Readme/run.png)
