-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 02, 2019 at 01:53 PM
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
-- Table structure for table `sk_lemmas_antonyms`
--

CREATE TABLE sk_lemmas_antonyms (
  lemma varchar(60) NOT NULL,
  pos char(1) NOT NULL,
  synset text
) 

--
-- Dumping data for table `sk_lemmas_antonyms`
--

INSERT INTO sk_lemmas_antonyms (lemma, pos, synset) VALUES
('aktuálny', 'A', 'neaktuálny'),    	
('bezcitný', 'B', 'citlivý'),     	
('chybný', 'A', 'bezchybný'),
('čestný', 'A', 'nečestný'),					
('dokonalý', 'A', 'nedokonalý'),		
('drahý', 'A', 'lacný'),				
('falošný', 'A', 'úprimný'),			
('hlavný', 'A', 'vedľajší'),	
('horúci', 'A', 'chladný,studený'),		
('hrubý', 'A', 'tenký'),			
('iný', 'A', 'ten,tento,taký'),	
('jasný', 'A', 'nejasný'),	

('malý', 'A', 'veľký'),		
('mimoriadny', 'A', 'riadny,bežný'),		
('mizerný', 'A', 'dobrý,výborný'),		
('mocný', 'A', 'slabý'),						
('morálny', 'A', 'amorálny,nemorálny'),	
('napätý', 'A', 'oslabený,uvoľnený'),		
('nechutný', 'A', 'chutný'),					
('neistý', 'A', 'istý'),												
('nekonečný', 'A', 'konečný'),				

('nenápadný', 'A', 'nápadný'),				
('neoblomný', 'A', 'ústupčivý,poddajný,mäkký'),		
('neobmedzený', 'A', 'obmedzený'),							
('nepodarený', 'B', 'podarený'),								
('nepokojný', 'B', 'pokojný,vyrovnaný'),					
('nepriaznivý', 'B', 'priaznivý'),							
('nereálny', 'B', 'reálny'),
('nepretržitý', 'B', 'nesúvislý'),
('nevhodný', 'B', 'vhodný'),
('neznámy', 'B', 'známy'),
('nešťastný', 'B', 'šťastný,blažený'),

('nezvyčajný', 'B', 'obyčajný'),
('nútený', 'B', 'dobrovoľný'),
('obranný', 'B', 'útočný'),
('poctivý', 'B', 'nepoctivý'),
('podobný', 'A', 'odlišný,rozdielny'),
('podstatný', 'B', 'nepodstatný'),
('pravý', 'A', 'falošný,nepravý'),
('premenlivý', 'B', 'nemenný'),
('primeraný', 'B', 'neprimeraný'),
('príťažlivý', 'A', 'nepríťažlivý,odpudivý,odpudzujúci'),
('rovný', 'B', 'krivý,nerovný'),
('rozdielny', 'B', 'rovnaký'),

('rozumný', 'B', 'nerozumný'),
('svižný', 'B', 'malátny'),
('tichý', 'B', 'rušný,hlasný');
('vnútorný', 'A', 'vonkajší'),
('živý', 'B', 'mŕtvy,neživý'),

--
-- Indexes for dumped tables
--

--
-- Indexes for table `sk_lemmas_antonyms`
--
ALTER TABLE `sk_lemmas_antonyms`
  ADD PRIMARY KEY (`lemma`,`pos`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
