-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 13, 2019 at 09:35 AM
-- Server version: 5.7.17
-- PHP Version: 7.1.3

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `nlp_playground`
--

-- --------------------------------------------------------

--
-- Table structure for table `sk_lemmas_synonyms`
--

CREATE TABLE sk_lemmas_synonyms (
  lemma varchar(60) NOT NULL,
  pos char(1) NOT NULL,
  synset text
) 

--
-- Dumping data for table `sk_lemmas_synonyms`
--

INSERT INTO sk_lemmas_synonyms (lemma, pos, synset) VALUES
('aktuálny', 'A', 'moderný,módny,súdobý,súčasný,dnešný,horúci,najnovší,nedávny,posledný,čerstvý'),
('bezcitný', 'B', 'animálny,beštiálny,brutálny,hrubý,krutý,surový,zverský,bezohľadný,cynický,necitlivý'),
('bezúhonný', 'A', 'férový,korektný,morálny,mravný,poctivý,počestný,seriózny,slušný,vzorný,vážený,čestný'),
('biedny', 'A', 'nedostačujúci,nepostačujúci,neuspokojivý,nevyhovujúci,úbohý,žalostný,chatrný,mizerný,naničhodný,nepodarený,psotný,psovský,psí,zlý,úbohy,žobrácky'),
('čestný', 'A', 'bezúhonný,férový,korektný,morálny,mravný,poctivý,počestný,seriózny,slušný,vzorný,vážený'),
('charakteristický', 'A', 'osobitý,príznačný,svojrázny,typický,výrazný,význačný,svojský,nápadný,markantný,špecifický'),
('chybný', 'A', 'defektný,falošný,klamný,mylný,nedokonalý,nekvalitný,nepravdivý,nesprávny,vadný,špatný'),
('diskutabilný', 'A', 'neistý,nerozhodný,nezaručený,pochybný,problematický,rozpačitý,sporný'),
('dokonalý', 'A', 'ideálny,obdivuhodný,vynikajúci,výborný,úctyhodný,absolútny,bezpodmienečný,bezvýhradný,neobmedzený,perfektný,stopercentný,totálny,zvrchovaný,úplný,bezchybný'),
('drahý', 'A', 'cenný,drahocenný,hodnotný,honosný,luxusný,nákladný,prepychový,vzácny,významný,význačný'),

('drobný', 'A', 'drobunký,malinký,maličký,malý,miniatúrny,nepatrný,filigránsky,útly,subtílny,šťúply,šťúplušký,liliputánsky,mikroskopický,myšací,drobčivý,drobnulinký,drobulinký,drobušký,drobučký,drobnuľký,drobnušký,zakrpatený,krpatý'),
('elegantný', 'A', 'apartný,slušivý,distingvovaný,hladký,jemný,uhladený,ulízaný,vyhladený,zdvorilý,graciózny,krásny,ladný,pôvabný'),
('falošný', 'A', 'dvojaký,farizejský,fingovaný,nepravý,neúprimný,obojaký,pokrytecký,predstieraný,strojený,zdanlivý,údajný,chybný,defektný,klamný,mylný,nedokonalý,nekvalitný,nepravdivý,nesprávny,vadný,špatný'),
('hlavný', 'A', 'elementárny,neodmysliteľný,podstatný,primárny,základný,zásadný,kľúčový,prevažný,prevažujúci,prvoradý,rozhodujúci,ústredný,fundamentálny,kardinálny,prvý,najdôležitejší,najvýznamnejší,centrálny,titulný,stoličný,dominantný,nosný,oporný,generálny,vedúci,hegemónny,korunný'),
('horúci', 'A', 'rozpálený,žeravý,žhavý,aktuálny,dnešný,najnovší,nedávny,posledný,čerstvý,rozhorúčený,rozohriaty,zohriaty,vriaci,pálivý,pálčivý,tropický'),
('hotový', 'A', 'pripravený,skončený,ukončený,zakončený,dovŕšený,zavŕšený,urobený,dorobený,dohotovený,vyhotovený,prichystaný,nachystaný,doštudovaný,vyštudovaný'),
('hrubý', 'A', 'animálny,bezcitný,beštiálny,brutálny,krutý,surový,zverský,brutto,nemotorný,neobratný,neogabaný,neohrabaný,neokresaný,neokrôchaný,neotesaný,neuhladený,drsný,masívny,tučný,hrubizný,hrubočizný,prihrubý'),
('hypotetický', 'A', 'domnelý,fiktívny,imaginárny,neskutočný,pomyselný,predpokladaný,predstieraný,vymyslený,zdanlivý,údajný,teoretický'),
('imaginárny', 'A', 'domnelý,fiktívny,hypotetický,neskutočný,pomyselný,predpokladaný,predstieraný,vymyslený,zdanlivý,údajný,iluzórny,klamný,lživý,mylný,mätúci,nepresný,nereálny,neživotný'),
('iný', 'A', 'diferencovaný,nerovnaký,odlišný,rozdielny,rozličný,rozmanitý,rôznorodý,rôzny,druhý,ďalší,inakší,odchodný,odchylný,onaký,alternatívny'),

('jasný', 'A', 'priehľadný,priesvitný,priezračný,tenunký,transparentný,číry,evidentný,jednoznačný,očividný,zjavný,zrejmý,zreteľný,intenzívny,iskrivý,lesklý,rozžiarený,svetlý,svietiaci,žiariaci,žiarivý,krikľavý,markantný,nápadný,názorný,okatý,rozoznateľný,viditeľný,badateľný,citeľný,pozorovateľný'),
('jedinečný', 'A', 'exkluzívny,mimoriadny,neobyčajný,nezrovnateľný,vybraný,výnimočný,báječný,nádherný,ohromný,prekrásny,skvelý,utešený,výborný,znamenitý,úžasný,unikátny'),
('kľúčový', 'A', 'hlavný,prevažný,prevažujúci,prvoradý,rozhodujúci,základný,zásadný,ústredný,fundamentálny,kardinálny,podstatný'),
('kolosálny', 'A', 'enormný,fenomenálny,gigantický,monštruózny,nevyčísliteľný,obrovitý,obrovský,ohromný,veľký,nesmierny,ohromujúci'),
('krásny', 'A', 'nádherný,potešujúci,pôvabný,rozkošný,roztomilý,skvostný,elegantný,graciózny,ladný,mocný,neodolateľný,pôsobivý'),
('ľahostajný', 'A', 'apatický,bezmyšlienkovitý,bezstarostný,driemajúci,flegmatický,lenivý,nemajúci záujem,nevšímavý,nezúčastnený,nečinný,záhaľčivý'),
('liberálny', 'A', 'slobodomyseľný,tolerantný,znášanlivý,nezávislý,samostatný,slobodný,voľný'),
('luxusný', 'A', 'cenný,drahocenný,drahý,hodnotný,honosný,nákladný,prepychový,vzácny,významný,význačný'),
('malý', 'A', 'drobný,drobunký,malinký,maličký,miniatúrny,nepatrný,neveľký,nízky,priliehavý,tesný,úzky,nevysoký,nezreteľný,nebadaný,nebadateľný,nevýrazný,neviditeľný,mikroskopický,nedostačujúci,nedostatočný,slabý,chabý,zakrpatený,nedorastený,piadimužícky,škriatkovský,kolibričí,liliputánsky,skromný,obmedzený,šťúply,šťúplušký,zanedbateľný,mizivý,nepočetný,bagateľný,blšací,blší,koľký-toľký,aký-taký,primalý,maličičký,malilinký,malunký,malulinký,malučký,malučičký'),
('márny', 'A', 'zbytočný,daromný,neúčelný,bezúčelný,bezcieľny,bezvýsledný,neúspešný,nevydarený,bezcenný,neužitočný,prázdny,nezmyselný'),

('miestny', 'A', 'lokálny,regionálny,pomiestny,domáci,tunajší,tamojší,obecný'),
('mimoriadny', 'A', 'exkluzívny,jedinečný,neobyčajný,nezrovnateľný,vybraný,výnimočný,abnormálny,nenormálny,nepravidelný,nezvyčajný,odlišný,osobitný,zvláštny,neobvyklý,nevídaný,nevšedný,nezvyklý,nečakaný,zriedkavý'),
('mizerný', 'A', 'prekliaty,zatratený,čertovský,biedny,chatrný,mizerný,naničhodný,nepodarený,psotný,psovský,psí,zlý,úbohy,žobrácky'),
('mocný', 'A', 'dôležitý,markantný,mohutný,robustný,silný,vplyvný,významný,krásny,neodolateľný,pôsobivý'),
('morálny', 'A', 'bezúhonný,férový,korektný,mravný,poctivý,počestný,seriózny,slušný,vzorný,vážený,čestný,cnostný,etický'),
('mužný', 'A', 'chlapský,chrabrý,mužský,nebojácny,neohrozený,odvážny,rozhodný,smelý,statočný,udatný'),
('mylný', 'A', 'fiktívny,iluzórny,imaginárny,klamný,lživý,mätúci,nepresný,nereálny,neskutočný,neživotný,vymyslený,zdanlivý,chybný,defektný,falošný,nedokonalý,nekvalitný,nepravdivý,nesprávny,vadný,špatný'),
('naliehavý', 'A', 'bezodkladný,neodkladný,nevyhnutý,nutný,potrebný,súrny,akútny,okamžitý,nutkavý,obsedantný,vtieravý,dôležitý,nástojčivý,úpenlivý,neodbytný'),
('nápadný', 'A', 'jasný,krikľavý,markantný,názorný,okatý,rozoznateľný,viditeľný,zreteľný,výrazný,zjavný,veľký,evidentný'),
('napätý', 'A', 'napnutý,tenzný,úzkostný,koncentrovaný,pátravý,sústredený,uprený,upriamený'),

('nebezpečný', 'A', 'riskantný,ohrozujúci,hrozivý,kritický,krízový,rizikový,strašný,hrozný,zlý'),
('nechutný', 'A', 'hnusný,na zvracanie,odporný,odpudivý,ohavný,opovrhnutia hodný,protivný,rozčuľujúci'),
('neistý', 'A', 'diskutabilný,nerozhodný,nezaručený,pochybný,problematický,rozpačitý,sporný,bezradný,v rozpakoch,zmätený'),
('nekonečný', 'A', 'nemenný,neutíchajúci,stály,trvalý,ustavičný,večný,nesmierny,ohromný,neobmedzený,bezhraničný,bezmedzný,bezmerný,nedozerný,nedohľadný,zdĺhavý,rozsiahly,úplný'),
('nemý', 'A', 'mlčanlivý,nehlučný,tichý,mĺkvy,bezslovný,zamĺknutý,onemený'),
('nenápadný', 'B', 'nevtieravý,všedný,nevýrazný,kradmý,utajený,jednoduchý,jemný,diskrétny'),
('neoblomný', 'B', 'nepoddajný,nepodkupný,nezlomný,neúprosný,neústupný,neústupčivý,tvrdohlavý,húževnatý,vytrvalý'),
('neobmedzený', 'A', 'absolutistický,absolútny,bezpodmienečný,bezvýhradný,dokonalý,perfektný,stopercentný,totálny,zvrchovaný,úplný,infinitezimálny,neohraničený,nezávislý,samostatný,nekonečný,nehatený,nespútaný,nesputnaný,nepodmienený,široký,nekontrolovaný,nevyčerpateľný,nevysychavý'),
('neobvyklý', 'B', 'fenomenálny,nadpriemerný,neobyčajný,nevšedný,nezvyklý,ojedinelý,vynikajúci,výnimočný,mimoriadny,nevídaný,nezvyčajný,nečakaný,zriedkavý,zvláštny,bizardný,divný,podivný,čudný,neprirodzený,abnormálny'),

('nepodarený', 'B', 'biedny,chatrný,mizerný,naničhodný,psotný,psovský,psí,zlý,úbohy,žobrácky'),
('nepokojný', 'B', 'nervózny,pohnutý,rozrušený,rozčúlený,vyvedený z miery,vzrušený,znepokojený'),
('nepremožiteľný', 'A', 'neprekonateľný,nezdolateľný,nezdolný,neporaziteľný,nedobytný,pevný,nezlomný,neskrotný'),
('nepretržitý', 'B', 'neustály,permanentný,plynulý,pravidelný,stály,súvislý,trvalý,trvanlivý,ustavičný,večný,viacročný,vytrvalý,neprestajný'),
('nepriaznivý', 'B', 'dezolátny,katastrofálny,neblahý,nešťastný,úbohý,žalostný,negatívny,odmietavý,zamietavý,záporný'),
('nereálny', 'B', 'fiktívny,iluzórny,imaginárny,klamný,lživý,mylný,mätúci,nepresný,neskutočný,neživotný,vymyslený,zdanlivý'),
('nešťastný', 'B', 'beznádejný,skormútený,skľúčený,smutný,zarmútený,zdrvený,zúfalý,dezolátny,katastrofálny,neblahý,nepriaznivý,úbohý,žalostný,hrozný,tragický,zdrvujúci'),
('nevhodný', 'B', 'nehodiaci sa,nemiestny,nepatričný,neslušný,nesprávny,nespôsobilý,netaktný,nevychovaný,nevyhovujúci,grambľavý,kyptavý,nemotorný,neobratný,neohrabaný,nezručný,nešikovný,ľavý,ťarbavý,ťažkopádny'),
('neznámy', 'B', 'cudzokrajný,cudzí,exotický,mimozemský,anonymný,bezmenný,nepodpísaný,akýsi,nejaký,voľajaký,dajaký,dáky,nepoznaný,neodhalený,neidentifikovateľný,tajomný,záhadný,tajný,skrytý,utajený,neistý,nový'),

('nezvyčajný', 'B', 'abnormálny,mimoriadny,nenormálny,nepravidelný,odlišný,osobitný,zvláštny,neobvyklý,neobyčajný,nevídaný,nevšedný,nezvyklý,nečakaný,výnimočný,zriedkavý'),
('nútený', 'B', 'nedobrovoľný,neprirodzený,násilný,povinný,vynútený,zaviazaný,nevyhnutný,obligatórny,obligátny,záväzný,neúprimný'),
('obradný', 'A', 'ceremoniálny,formálny,slávnostný,sviatočný,škrobený,obradový,kultový,rítový,bohoslužobný,sakramentálny'),
('obranný', 'B', 'ochranný,obranársky,prevenčný,preventívny,imúnny,imunitný,ústupový,defenzívny'),
('obrátený', 'B', 'opačný,protikladný,protiľahlý,reverzný,inverzný,prevrátený,recipročný,doluznačky'),
('osobitý', 'B', 'charakteristický,príznačný,svojrázny,typický,výrazný,význačný,osobitý,špecifický,špeciálny'),
('poctivý', 'B', 'bezúhonný,férový,korektný,morálny,mravný,počestný,seriózny,slušný,vzorný,vážený,čestný,faktický,hmatateľný,konkrétny,naozajstný,nefalšovaný,pravdivý,pravý,rýdzi,skutočný,čistý,pedantský,puntičkársky,riadny,spoľahlivý,starostlivý,svedomitý,úzkostlivý'),
('podobný', 'B', 'analogický,korešpondujúci,obdobný,príbuzný,blízky,spriaznený,spríbuznený,podaný,podatý,rovnaký,zhodný,porovnateľný'),
('podstatný', 'B', 'elementárny,hlavný,neodmysliteľný,primárny,základný,zásadný,fundamentálny,kardinálny,kľúčový,kapitálny,rozhodujúci,principiálny,závažný,významný,dôležitý,bytostný,esencionálny,levský'),
('potrebný', 'B', 'bezodkladný,naliehavý,neodkladný,nevyhnutý,nutný,súrny,požadovaný,vhodný,vyhovujúci,želateľný,žiaduci'),

('povestný', 'A', 'chýrny,známy,chýrečný,svetoznámy,svetochýrny,uznávaný,slávny,preslávený,legendárny,príslovečný,typický'),
('pravý', 'B', 'faktický,hmatateľný,konkrétny,naozajstný,nefalšovaný,poctivý,pravdivý,rýdzi,skutočný,čistý,autentický,hodnoverný,originálny,pôvodný,ozajstný,opravdivý,nepredstieraný,plnokrvný,číry,stopercentný'),
('premenlivý', 'B', 'kolísavý,meniaci sa,nestály,variabilný,striedavý,menlivý,meňavý,menistý,menivý,aprílový,rozkolísaný,vrtkavý'),
('primeraný', 'B', 'akceptovateľný,dostatočný,dostačujúci,možný,postačujúci,prijateľný,uspokojivý,vhodný,adekvátny,patričný'),
('príťažlivý', 'A', 'lákavý,pútavý,mámivý,pôvabný,sugestívny,vábivý,vábny,zvodný'),
('rovný', 'B', 'plochý,rovinatý,lineárny,stály,priamy,priamočiary,vzpriamený,vystretý,vypätý,narovnaný,zarovnaný,usporiadaný,nezvlnený,rovinný,vodorovný,rovnunký,rovnulinký,rovnušký'),
('rozdielny', 'B', 'diferencovaný,iný,nerovnaký,odlišný,rozličný,rozmanitý,rôznorodý,rôzny,nerovný,nesúhlasný,odchodný,odchylný,diskrepantný'),
('rozprávkový', 'A', 'bájny,fantastický,mýtický,neskutočný,vybájený,vymyslený,kúzelný,magický,podivuhodný,zázračný,čarovný'),
('rozumný', 'B', 'diplomatický,obozretný,opatrný,ostražitý,predvídavý,prezieravý,taktický,umiernený,chladno uvažujúci,inteligentný,kľudný,logický,mierny,múdry,racionálny,rozvážny,uvážlivý,vyrovnaný,intelektuálny'),
('seriózny', 'B', 'bezúhonný,férový,korektný,morálny,mravný,poctivý,počestný,slušný,vzorný,vážený,čestný'),

('strelený', 'B', 'švihnutý,trafený,cvoknutý,bláznivý,pobláznený,zblbnutý,pojašený,zjašený,hlúpy,šibnutý'),
('svižný', 'B', 'elastický,ohybný,plastický,poddajný,pružný,tvárny,vláčny'),
('tichý', 'B', 'bojazlivý,hanblivý,krotký,nesmelý,nevýbojný,ostýchavý,plachý,zanovitý,mlčanlivý,nehlučný,nemý,pokojný,rozvážny,bezhlasný,nečujný,nepočuteľný,nezvučný,bezzvuký,polohlasný,polohlasitý,tlmený,pritlmený,pridusený,bezhlasý,bezhrmotný,tichulinký,tichunký'),
('úbohý', 'B', 'dezolátny,katastrofálny,neblahý,nepriaznivý,nešťastný,žalostný,biedny,nedostačujúci,nepostačujúci,neuspokojivý,nevyhovujúci'),
('vnútorný', 'B', 'domáci,interný,kradmý,pokútny,skrytý,tajný,utajovaný,podstatný,skutočný'),
('zarytý', 'B', 'notorický,skalný,zaťatý,neoblomný,tvrdohlavý,tvrdošijný,hlavatý,nezmieriteľný,tvrdý,zatvrdnutý,zatvrdlivý'),
('zavalitý', 'B', 'objemný,korpulentný,silný,mohutný,robustný,plný,plnší,plnoštíhly,silnejší,územčistý,oblý,okrúhly,guľatý,zaokrúhlený,zaguľatený,bucľatý'),
('závažný', 'B', 'fatálny,osudný,osudový,relevantný,rozhodujúci,smerodatný,významný,dôležitý,kritický,vážny,životný'),
('zdanlivý', 'B', 'domnelý,fiktívny,hypotetický,imaginárny,neskutočný,pomyselný,predpokladaný,predstieraný,vymyslený,údajný,dvojaký,falošný,farizejský,fingovaný,nepravý,neúprimný,obojaký,pokrytecký,strojený,iluzórny,klamný,lživý,mylný,mätúci,nepresný,nereálny,neživotný,iluzívny,klamlivý'),
('živý', 'A', 'hektický,rušný,bujarý,divý,nespútaný,neviazaný,roztopašný,veselý,bystrý,čulý,žijúci,živučičký')

--
-- Indexes for dumped tables
--

--
-- Indexes for table `sk_lemmas_synonyms`
--