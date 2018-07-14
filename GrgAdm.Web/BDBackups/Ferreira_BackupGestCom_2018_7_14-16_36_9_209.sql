-- MySqlBackup.NET 2.0.12
-- Dump Time: 2018-07-14 16:36:10
-- --------------------------------------
-- Server version 8.0.11 MySQL Community Server - GPL


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of atualizacao
-- 

DROP TABLE IF EXISTS `atualizacao`;
CREATE TABLE IF NOT EXISTS `atualizacao` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `VersaoRelease` int(11) NOT NULL DEFAULT '0',
  `VersaoUpdate` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table atualizacao
-- 

/*!40000 ALTER TABLE `atualizacao` DISABLE KEYS */;
INSERT INTO `atualizacao`(`id`,`VersaoRelease`,`VersaoUpdate`) VALUES
(1,1,1);
/*!40000 ALTER TABLE `atualizacao` ENABLE KEYS */;

-- 
-- Definition of login
-- 

DROP TABLE IF EXISTS `login`;
CREATE TABLE IF NOT EXISTS `login` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(30) NOT NULL,
  `password` varchar(8) NOT NULL,
  `codigo` int(11) NOT NULL,
  `perfil` int(11) NOT NULL,
  `Nome` varchar(45) NOT NULL,
  `n_acessos` int(11) DEFAULT '0',
  `bloqueio_motivo` varchar(200) DEFAULT NULL,
  `bloqueio_data` datetime DEFAULT NULL,
  `criacao_data` datetime DEFAULT NULL,
  `bloqueado` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username_UNIQUE` (`username`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `codigo_UNIQUE` (`codigo`),
  KEY `id_idx` (`perfil`),
  CONSTRAINT `id` FOREIGN KEY (`perfil`) REFERENCES `perfis` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table login
-- 

/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login`(`id`,`username`,`password`,`codigo`,`perfil`,`Nome`,`n_acessos`,`bloqueio_motivo`,`bloqueio_data`,`criacao_data`,`bloqueado`) VALUES
(3,'1','1',1,1,'Jorge',4,NULL,NULL,'2018-07-13 21:56:26',0);
/*!40000 ALTER TABLE `login` ENABLE KEYS */;

-- 
-- Definition of perfis
-- 

DROP TABLE IF EXISTS `perfis`;
CREATE TABLE IF NOT EXISTS `perfis` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(30) NOT NULL,
  `ativo` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table perfis
-- 

/*!40000 ALTER TABLE `perfis` DISABLE KEYS */;
INSERT INTO `perfis`(`id`,`descricao`,`ativo`) VALUES
(1,'Administrador',1);
/*!40000 ALTER TABLE `perfis` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2018-07-14 16:36:12
-- Total time: 0:0:0:2:571 (d:h:m:s:ms)
