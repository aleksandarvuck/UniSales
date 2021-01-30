CREATE TABLE dbo.Grupa ( 
	GrupaID              int NOT NULL   IDENTITY ,
	Ime                  nvarchar(500) NOT NULL    ,
	CONSTRAINT Pk_Grupa_GrupaID PRIMARY KEY  ( GrupaID )
 );

CREATE TABLE dbo.Korisnik ( 
	KorisnikID           int NOT NULL   IDENTITY ,
	Ime                  nvarchar(100) NOT NULL    ,
	Prezime              nvarchar(100) NOT NULL    ,
	Email                nvarchar(50) NOT NULL    ,
	Lozinka              nvarchar(max) NOT NULL    ,
	KorisnickoIme        nvarchar(100) NOT NULL    ,
	CONSTRAINT Pk_Korisnik_KorisnikID PRIMARY KEY  ( KorisnikID )
 );

CREATE TABLE dbo.Kupac ( 
	KupacID              int NOT NULL   IDENTITY ,
	Ime                  nvarchar(250) NOT NULL    ,
	Prezime              nvarchar(250) NOT NULL    ,
	Telefon              nvarchar(250) NOT NULL    ,
	Email                nvarchar(250) NOT NULL    ,
	Adresa               nvarchar(500) NOT NULL    ,
	KorisnickoIme        nvarchar(100) NOT NULL    ,
	Lozinka              nvarchar(max) NOT NULL    ,
	CONSTRAINT Pk_Kupac_KupacID PRIMARY KEY  ( KupacID )
 );

CREATE TABLE dbo.Porudzbina ( 
	PorudzbinaID         int NOT NULL   IDENTITY ,
	DatumKreiranja       datetime  CONSTRAINT [defo_Porudzbina_DatumKreiranja] DEFAULT sysdatetime()   ,
	DatumPorudzbine      datetime NOT NULL    ,
	[Status]             bit NOT NULL CONSTRAINT [defo_Porudzbina_Status] DEFAULT 0   ,
	BrojNarudzbenice     int NOT NULL    ,
	DatumIzmene          datetime     ,
	ProizvodID           int     ,
	KorisnikID           int NOT NULL    ,
	KupacID              int NOT NULL    ,
	CONSTRAINT Pk_Porudzbina_PorudzbinaID PRIMARY KEY  ( PorudzbinaID ),
	CONSTRAINT Unq_Porudzbina_ProizvodID UNIQUE ( ProizvodID ) 
 );

CREATE TABLE dbo.Proizvod ( 
	ProizvodID           int NOT NULL   IDENTITY ,
	Ime                  nvarchar(250) NOT NULL    ,
	Tip                  nvarchar(250) NOT NULL    ,
	Opis                 nvarchar(max) NOT NULL    ,
	DatumPostavljanja    datetime NOT NULL    ,
	CONSTRAINT Pk_Proizvod_ProizvodID PRIMARY KEY  ( ProizvodID )
 );

CREATE TABLE dbo.ProizvodGrupa ( 
	ProizvodID           int NOT NULL    ,
	GrupaID              int NOT NULL    
 );

CREATE TABLE dbo.PorudzbinaProizvod ( 
	PorudzbinaProizvodID int NOT NULL   IDENTITY ,
	ProizvodID           int NOT NULL    ,
	Cena                 int NOT NULL    ,
	CONSTRAINT Pk_PorudzbinaProizvod_PorudzbinaProizvodID PRIMARY KEY  ( PorudzbinaProizvodID )
 );

ALTER TABLE dbo.Porudzbina ADD CONSTRAINT Fk_Porudzbina_Korisnik FOREIGN KEY ( KorisnikID ) REFERENCES dbo.Korisnik( KorisnikID ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE dbo.Porudzbina ADD CONSTRAINT Fk_Porudzbina_Kupac FOREIGN KEY ( KupacID ) REFERENCES dbo.Kupac( KupacID ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE dbo.PorudzbinaProizvod ADD CONSTRAINT Fk_PorudzbinaProizvod_Proizvod FOREIGN KEY ( ProizvodID ) REFERENCES dbo.Proizvod( ProizvodID ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE dbo.PorudzbinaProizvod ADD CONSTRAINT Fk_PorudzbinaProizvod_Porudzbina FOREIGN KEY ( ProizvodID ) REFERENCES dbo.Porudzbina( ProizvodID ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE dbo.ProizvodGrupa ADD CONSTRAINT Fk_ProizvodGrupa_Grupa FOREIGN KEY ( GrupaID ) REFERENCES dbo.Grupa( GrupaID ) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE dbo.ProizvodGrupa ADD CONSTRAINT Fk_ProizvodGrupa_Proizvod FOREIGN KEY ( ProizvodID ) REFERENCES dbo.Proizvod( ProizvodID ) ON DELETE NO ACTION ON UPDATE NO ACTION;

