﻿USE `gestcom`;
DROP procedure IF EXISTS `VerificarLogin`;

DELIMITER $$
USE `gestcom`$$
CREATE PROCEDURE `VerificarLogin` ( IN usern varchar(30), IN passw varchar(30), OUT result int)
BEGIN

SELECT result = id FROM gestcom.login l WHERE l.username =  usern AND l.password = passw;

IF((SELECT bloqueado FROM gestcom.login WHERE id = result) = 1) THEN
	SELECT bloqueado, bloqueio_motivo, bloqueio_data FROM gestcom.login WHERE id = result;
ELSE
	SELECT id, username, codigo, perfil, Nome, n_acessos FROM gestcom.login WHERE id = result;
END IF;

END$$

DELIMITER ;