# Campo Minato

Ovvero [Campo Minato/Prato Fiorito](https://it.wikipedia.org/wiki/Campo_minato_(videogioco)) ricreato in [C#](https://learn.microsoft.com/it-it/dotnet/csharp/) con [Windows Forms](https://learn.microsoft.com/it-it/dotnet/desktop/winforms/overview/?view=netdesktop-8.0) e la versione [4.7.2 del framework .NET](https://support.microsoft.com/it-it/topic/programma-di-installazione-offline-di-microsoft-net-framework-4-7-2-per-windows-05a72734-2127-a15d-50cf-daf56d5faec2).

## Interfaccia

### Interfaccia principale

![Campo](https://i.imgur.com/K9Rxth8.png)

> All'avvio del programma il gioco è già avviato, con tutte le caselle chiuse nella griglia.
> 
> 
> I numeri a sinistra indicano il tempo passato dall'inizio della partita, mentre i numeri a destra indicano il numero di bombe presenti nel campo.
> 
> L’interfaccia viene scalata automaticamente in base al numero di righe e colonne.
> 

![Caselle](https://i.imgur.com/sbROxUF.png)

> Cliccando con il tasto sinistro su una casella, essa verrà scoperta e rivelerà una casella vuota, una bomba, o un numero che indica le bombe adiacenti a quella casella.
> 
> 
> Cliccando con il tasto destro si posizionerà una bandiera, che indica la presenza di una bomba nella casella corrente, e cliccando di nuovo si posizionerà un '?' che indica la probabilità della presenza di una bomba.
> 

![Sconfitta](https://i.imgur.com/Ehg90Hp.png)

> Se apri una casella contenente una bomba hai perso.
> 
> 
> Il gioco mostrerà tutte le bombe presenti nel campo e comparirà un pulsate per giocare di nuovo.
> 

![Vittoria](https://i.imgur.com/1KS9Sit.png)

> Se piazzi una bandierina su tutte le caselle contenenti una bomba hai vinto.
> 
> 
> Il gioco mostrerà un pulsate per giocare di nuovo.
> 

### Menù di configurazione

![Menu](https://i.imgur.com/XTWK5Hf.png)

> Il menù delle impostazioni è molto basilare e presenta le opzioni per regolare il numero di righe e di colonne del campo e la percentuale di caselle nel campo che contengono una bomba.
> 
> 
> Le impostazioni vengono scaricate e caricate dal file `config.xml` e possono essere modificate anche modificando quel file.
> 

### File di configurazione

```xml
<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<PartoMinato>
    <Righe>8</Righe>
    <Colonne>8</Colonne>
    <Riempimento>12</Riempimento>
</PartoMinato>
```

> Questa è la formattazione e i campi del file di configurazione `config.xml`.