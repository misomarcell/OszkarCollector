-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: oszkar
-- ------------------------------------------------------
-- Server version	5.7.19-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `rides`
--

DROP TABLE IF EXISTS `rides`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rides` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `uri` varchar(250) NOT NULL,
  `price` varchar(45) NOT NULL,
  `vehicle_brand` varchar(45) NOT NULL,
  `vehicle_model` varchar(45) NOT NULL,
  `vehicle_year` int(11) NOT NULL,
  `driver_username` varchar(45) NOT NULL,
  `driver_uri` varchar(250) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rides`
--

LOCK TABLES `rides` WRITE;
/*!40000 ALTER TABLE `rides` DISABLE KEYS */;
INSERT INTO `rides` VALUES (1,'https://www.oszkar.com/telekocsi/185814768-Debrecen-Munchen-2018-03-17.html','74 euro','Renault','TRAFFIC',2015,'e-flotta','https://www.oszkar.com/user/profile.php?user=1515493618:e-flotta&caroffer_id=185814768'),(2,'https://www.oszkar.com/telekocsi/198405534-Szekesfehervar-Koln-2018-03-17.html','90 euro','Ford','Galaxy',2008,'Presztizstaxi','https://www.oszkar.com/user/profile.php?user=1519900018:Presztizstaxi&caroffer_id=198405534'),(3,'https://www.oszkar.com/telekocsi/186254547-Landshut-Nyiregyhaza-2018-03-17.html','19500 Ft','Ford','Tranzit',2006,'LiveCar','https://www.oszkar.com/user/profile.php?user=1519208818:LiveCar&caroffer_id=186254547'),(4,'https://www.oszkar.com/telekocsi/185981772-Debrecen-Augsburg-2018-03-17.html','89 euro','Renault','TRAFFIC',2015,'e-flotta','https://www.oszkar.com/user/profile.php?user=1515666419:e-flotta&caroffer_id=185981772'),(5,'https://www.oszkar.com/telekocsi/198405537-Szekesfehervar-Venlo-2018-03-17.html','90 euro','Ford','Galaxy',2008,'Presztizstaxi','https://www.oszkar.com/user/profile.php?user=1520504819:Presztizstaxi&caroffer_id=198405537'),(6,'https://www.oszkar.com/telekocsi/185814771-Debrecen-Memmingen-2018-03-17.html','89 euro','Renault','TRAFFIC',2015,'e-flotta','https://www.oszkar.com/user/profile.php?user=1516703219:e-flotta&caroffer_id=185814771'),(7,'https://www.oszkar.com/telekocsi/185981775-Debrecen-Ulm-2018-03-17.html','95 euro','Renault','TRAFFIC',2015,'e-flotta','https://www.oszkar.com/user/profile.php?user=1520504819:e-flotta&caroffer_id=185981775'),(8,'https://www.oszkar.com/telekocsi/198405540-Szekesfehervar-Eindhoven-2018-03-17.html','90 euro','Ford','Galaxy',2008,'Presztizstaxi','https://www.oszkar.com/user/profile.php?user=1520850420:Presztizstaxi&caroffer_id=198405540');
/*!40000 ALTER TABLE `rides` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-17 15:01:41
