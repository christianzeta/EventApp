# ASP.NET CORE och dess användningsområde

ASP.NET CORE är ett bibliotek för att skapa webbapplikationer med till exempel C# kod på server sidan som sedan kan köras på alla olika operativsystem.
När ett projekt startas i ASP.NET CORE medföljer Startup.cs, Program.cs och wwwroot mappen. Sedan kan även Razor språket användas.
När programmet startar så registreras de olika services som har tillämpats i Startup.cs, för Razor Pages används "services.addRazorPages". 
Det är även här ett databaskontext läggs till oavsett om det är Razor Pages eller t.ex. MVC.  När en service läggs till används dependency injection som ser till att det 
skapas objekt som olika sidor enkelt kan få tag på. Efter services lagts till körs programmet Main i Program.cs där en Host skapas. 

Sedan körs configure i Startup.cs som fungerar som en pipeline för olika http request, där en request går igenom stegen uppifrån och ned, och sedan tillbaka igen för att modifiera request och respons.
Mappen wwwroot innehåller de statiska filer som servern kan skicka tillbaka till webbläsaren utan att modifiera de innan, de skickas precis som de är. 
Dessa filer är CSS, javascript och bilder. CSS och Javascript kan dynamiskt förändra hur en hemsida ser ut och agerar, men allt det händer i webbläsaren till skillnad från i servern. En Razor Page omvandlas istället på servern för att representera värden av uttryck som sedan skickas till webbläsaren som en statisk html sida, och varje gång en request sker så görs något på server sidan som förändrar koden och skickar ett nytt svar. 
Med Razor språket / syntaxen så är det möjligt att kombinera helt vanlig C# med HTML på samma sida. Genom att på detta sättet kombinera frontend med backend kommer fördelar och nackdelar beroende på ens utvecklingsstil. Genom att helt separera koden kan det bli enklare och tydligare att se vart man gjort fel och koden kan kännas mer enhetlig. Däremot känns det även mer intuitivt att direkt i HTML koden kunna generera dynamisk kod. 
Utöver Razor språket får utvecklaren även tillgång till Tag Helpers från ASP.NET CORE som hjälper till att göra HTML koden mer dynamisk. 

# De olika delarna i en Razor Pages Applikation och hur de hänger ihop

När utvecklingen sker i Razor Pages skapas en Content Page med tillhörande Page Model. det är fullt möjligt att skriva all logik och HTML kod i Content Page 
och helt strunta i Page Model, men anledningen till att det finns är för att separera logik från det som användaren i slutet skall ta del av.
En Content Page definieras av @Page som står högst upp i filen och under står det vilken Model Page som den kommer att hämta information från.  

På denna sidan skrivs HTML kod som kommer att skickas till webbläsaren blandat med C# kod som först utväderas på serven. 
Detta görs genom att skriva vanlig HTML och när C# används skrivs det antingen på en rad med hjälp av "@" först, eller i ett block genom "@{ kodblock }".  
Här kan utvecklaren även använda data som hämtas / manipuleras i den tillhörande Model Page klassen genom att skriva "@Model.x.x".
Model Page är en klass som tillhör en Content Page där logik hamnar samt t.ex. koppling till en databas. F
rämst används det för att hantera olika request genom "OnGet(), OnPost()". Nä
r en request kommer in till servern går den först igenom Model Page och genererar sedan Content Page som skickas tillbaka till användaren. 
ModelPage blir alltså en kortlivad instans av en klass som bara finns under skeendet av en request. 

# Vilka delar ingår i en MVC Applikation och hur de hänger ihop

Medan Razor Pages använder en mapp som heter Pages där de tillhörande Model Page och Content Page ligger så använder en MVC applikation ett annat design mönster. 
Här är det fokus på mapparna "Models", "Views" och "Controllers". Views mappen kan liknas med Content Page för Razor Pages,
här skrivs HTML kod som tillsammans med Razor språket kan lägga in vanlig C#. 

En Controller kan jämföras med en ModelPage men en av skillnaderna är att det fanns en Model Page för varje Content Page,
medan i MVC så kan en Controller användas för flera Views. Controllern sköter oftast hanteringen av requesten till de olika sidor som den arbetar med, 
men också för att kommunicera med olika Models eller en datasbas.
Models mappen finns i både Razor Pages och MVC där oftast en klass beskriver en datastruktur, 
det kan vara ett table i en databas eller en klass som skickas in och används av en View. 
De senare nämnda brukar av konvention döpas till "XxxViewModel", i en View precis som i en Page Model kan denna klass användas genom att högst upp definera "@Model XxxViewModel".  Det blir ytterligare en separation of concern där data delas upp efter användningsområde. 
















