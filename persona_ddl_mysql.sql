-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema arq_per_db
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema arq_per_db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `arq_per_db` DEFAULT CHARACTER SET latin1 ;
USE `arq_per_db` ;

-- -----------------------------------------------------
-- Table `arq_per_db`.`persona`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `arq_per_db`.`persona` (
  `cc` INT(15) NOT NULL,
  `nombre` VARCHAR(45) NOT NULL,
  `apellido` VARCHAR(45) NOT NULL,
  `genero` ENUM('M', 'F') NOT NULL,
  `edad` INT(3) NULL DEFAULT NULL,
  PRIMARY KEY (`cc`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `arq_per_db`.`profesion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `arq_per_db`.`profesion` (
  `id` INT(6) NOT NULL,
  `nom` VARCHAR(90) NOT NULL,
  `des` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `arq_per_db`.`estudios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `arq_per_db`.`estudios` (
  `id_prof` INT(6) NOT NULL,
  `cc_per` INT(15) NOT NULL,
  `fecha` DATE NULL DEFAULT NULL,
  `univer` VARCHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (`id_prof`, `cc_per`),
  INDEX `estudio_persona_fk` (`cc_per` ASC) VISIBLE,
  CONSTRAINT `estudio_persona_fk`
    FOREIGN KEY (`cc_per`)
    REFERENCES `arq_per_db`.`persona` (`cc`),
  CONSTRAINT `estudio_profesion_fk`
    FOREIGN KEY (`id_prof`)
    REFERENCES `arq_per_db`.`profesion` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `arq_per_db`.`telefono`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `arq_per_db`.`telefono` (
  `num` VARCHAR(15) NOT NULL,
  `oper` VARCHAR(45) NOT NULL,
  `duenio` INT(15) NOT NULL,
  PRIMARY KEY (`num`),
  INDEX `telefono_persona_fk` (`duenio` ASC) VISIBLE,
  CONSTRAINT `telefono_persona_fk`
    FOREIGN KEY (`duenio`)
    REFERENCES `arq_per_db`.`persona` (`cc`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
