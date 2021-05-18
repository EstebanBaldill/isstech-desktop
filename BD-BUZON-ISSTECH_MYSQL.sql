-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 18-05-2021 a las 04:51:25
-- Versión del servidor: 8.0.21
-- Versión de PHP: 7.2.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `buzon`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clips`
--

DROP TABLE IF EXISTS `clips`;
CREATE TABLE IF NOT EXISTS `clips` (
  `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `apellido_paterno` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `apellido_materno` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `direccions`
--

DROP TABLE IF EXISTS `direccions`;
CREATE TABLE IF NOT EXISTS `direccions` (
  `id_direccion` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  `codigo_postal` int NOT NULL,
  `calle` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `numero` int NOT NULL,
  `colonia` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `ciudad_municipio` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id_direccion`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `direccions`
--

INSERT INTO `direccions` (`id_direccion`, `codigo_postal`, `calle`, `numero`, `colonia`, `ciudad_municipio`) VALUES
(1, 29099, 'san terror', 19, 'santa ana', 'tuxtla gutierrez'),
(2, 29099, 'san terror', 19, 'santa ana', 'tuxtla gutierrez'),
(3, 29099, 'san marcos', 10, 'san teresa', 'Tuxtla gutierrez chiapas'),
(4, 29000, 'santa cecilia', 190, 'san catarro', 'tuxtla gutierrez'),
(5, 29098, 'jardines', 166, 'pedregal', 'tuxtla gutierrez'),
(6, 20397, 'san martin', 90, 'san catarro', 'tuxtla gutierrez'),
(7, 20397, 'san martin', 90, 'san catarro', 'tuxtla gutierrez'),
(8, 29090, 'SAN MARTIN', 10, 'SANTA ANA', 'TUXTLA GUTIERREZ'),
(9, 29062, 'PROYECTO', 10, 'SOFTWARE', 'TUXTLA GUTIERREZ'),
(10, 29090, 'san martin', 10, 'santa ana', 'TUXTLA GUTIERREZ'),
(11, 29090, 'san martin', 10, 'santa ana', 'TUXTLA GUTIERREZ');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `migrations`
--

DROP TABLE IF EXISTS `migrations`;
CREATE TABLE IF NOT EXISTS `migrations` (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `migration` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `migrations`
--

INSERT INTO `migrations` (`id`, `migration`, `batch`) VALUES
(1, '2014_10_12_000000_create_users_table', 1),
(2, '2014_10_12_100000_create_password_resets_table', 1),
(3, '2021_03_18_021757_create_clips_table', 1),
(4, '2021_04_01_030308_create_direccions_table', 1),
(5, '2021_04_01_034117_create_no_derechohabientes_table', 1),
(6, '2021_04_04_043443_create_queja__sugerencia__felicitacions_table', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `no_derechohabientes`
--

DROP TABLE IF EXISTS `no_derechohabientes`;
CREATE TABLE IF NOT EXISTS `no_derechohabientes` (
  `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `apellido_paterno` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `apellido_materno` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `no_derechohabientes`
--

INSERT INTO `no_derechohabientes` (`id`, `nombre`, `apellido_paterno`, `apellido_materno`) VALUES
(1, 'Jesus', 'perez', 'perez'),
(2, 'edgar otorro', 'alvarado', 'aguilar'),
(3, 'freddy', 'padilla', 'balcazar'),
(4, 'Freddy', 'padilla', 'padilla'),
(5, 'Freddy', 'padilla', 'padilla');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `password_resets`
--

DROP TABLE IF EXISTS `password_resets`;
CREATE TABLE IF NOT EXISTS `password_resets` (
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  KEY `password_resets_email_index` (`email`(250))
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `queja__sugerencia__felicitacions`
--

DROP TABLE IF EXISTS `queja__sugerencia__felicitacions`;
CREATE TABLE IF NOT EXISTS `queja__sugerencia__felicitacions` (
  `id_Queja_Sugerencia_Felicitacion` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  `id_clips_fk` bigint UNSIGNED DEFAULT NULL,
  `id_nodhabientes_fk` bigint UNSIGNED DEFAULT NULL,
  `anonimo` tinyint(1) DEFAULT NULL,
  `telefono_celular` bigint UNSIGNED DEFAULT NULL,
  `correo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `id_direccion_fk` bigint UNSIGNED DEFAULT NULL,
  `tipo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `nombre_del_servidor_publico` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `cargo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `area_de_servicio` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `descripcion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `fecha_hora` datetime NOT NULL,
  `estatus` int DEFAULT NULL,
  PRIMARY KEY (`id_Queja_Sugerencia_Felicitacion`),
  KEY `queja__sugerencia__felicitacions_id_clips_fk_foreign` (`id_clips_fk`),
  KEY `queja__sugerencia__felicitacions_id_nodhabientes_fk_foreign` (`id_nodhabientes_fk`),
  KEY `queja__sugerencia__felicitacions_id_direccion_fk_foreign` (`id_direccion_fk`)
) ENGINE=MyISAM AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `queja__sugerencia__felicitacions`
--

INSERT INTO `queja__sugerencia__felicitacions` (`id_Queja_Sugerencia_Felicitacion`, `id_clips_fk`, `id_nodhabientes_fk`, `anonimo`, `telefono_celular`, `correo`, `id_direccion_fk`, `tipo`, `nombre_del_servidor_publico`, `cargo`, `area_de_servicio`, `descripcion`, `fecha_hora`, `estatus`) VALUES
(1, NULL, NULL, 1, NULL, NULL, NULL, 'Felicitación', 'jose ortiz jaime estrada', 'contador', 'Cobros', 'Me cobro de mala gana', '2021-12-12 12:52:00', 0),
(2, 7127721, NULL, 0, 9613898765, 'dross@gmail.com', 2, 'Queja', 'mauricio perez muñon', 'Conserje', 'Otro', 'No barrio bien', '2021-05-16 05:05:00', 0),
(3, NULL, 1, 0, 961787986, 'perezperezjesus@gmail.com', 3, 'Sugerencia', 'Federico perez Guzman', 'administrativo', 'Administrativo', 'No me otorgo la atención necesaria.', '2021-05-20 16:07:00', 0),
(4, NULL, NULL, 1, NULL, NULL, NULL, 'Queja', 'jorge perez muños', 'gerente', 'Administrativo', 'No me otorgo la atencion necesaria', '2021-05-07 16:21:00', 0),
(5, NULL, 2, 0, 9617872656, 'estivenesdas@gmail.com', 4, 'Felicitación', 'Palma real estrada', 'recepcionista', 'Administrativo', 'Me atencio de una manera muy amable', '2021-05-21 17:27:00', 0),
(6, NULL, NULL, 1, NULL, NULL, NULL, 'Felicitación', 'Palma real estrada', 'Contador', 'Administrativo', 'Hola que tal', '2021-05-11 06:12:00', NULL),
(7, NULL, NULL, 1, NULL, NULL, NULL, 'Sugerencia', 'mauricio perez muñon', 'Contador', 'Administrativo', 'Muy bien bien bien', '2021-05-16 07:13:00', 0),
(8, 121223, NULL, 0, 961254896, 'estebanfenixx@gmail.com', 7, 'Queja', 'jorge ortiz mendez', 'secretario', 'Administrativo', 'Me dio una hoja en blanco.', '2021-05-16 07:15:00', 0),
(9, NULL, 3, 0, 961254896, 'freddypadilla190@gmail.com', 8, 'Felicitación', 'jose ortiz jaime estrada', 'contador', 'Cobros', 'PROBANDO LA CAJA DE MENSAJES', '2021-05-08 01:05:00', 0),
(10, NULL, NULL, 1, NULL, NULL, NULL, 'Felicitación', 'Federico perez Guzman', 'Programador', 'Otro', 'ESTA ES UNA PRUEBA DE MENSAJE ANONIMO', '2021-05-18 18:11:00', 0),
(11, 12345, NULL, 0, 9611234567, 'a170049@unach.mx', 9, 'Queja', 'mauricio perez muñon', 'DOCTOR', 'Atencion medica', 'PRUEBA DE MENSAJE', '2021-05-12 09:16:00', 0),
(12, NULL, 5, 0, 961254896, 'a170049@unach.mx', 11, 'Felicitación', 'aburto villareal orozco', 'Asesor', 'Administrativo', 'Hola que tal me gustaría felicitar al licenciado Aburto sobre la atención que me otorgo el 05/15/2021 , fue excelente y muy agradable, le doy un 10/10.', '2021-05-15 11:32:00', 0),
(13, NULL, NULL, 1, NULL, NULL, NULL, 'Felicitación', 'jose ortiz jaime estrada', 'ninguno', 'Administrativo', '1234567890\'¿\'0987654321234567890987654321234567890\'09876543212345678886867863891283612783689127368912638912398127389017389712980371289037128937890123789127390812738901738901273890777771289371289738921371289371893718937121273218373283723837', '2021-05-06 10:39:00', NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `email_verified_at` timestamp NULL DEFAULT NULL,
  `password` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `remember_token` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `contra_c` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `users_email_unique` (`email`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `users`
--

INSERT INTO `users` (`id`, `name`, `email`, `email_verified_at`, `password`, `remember_token`, `created_at`, `updated_at`, `contra_c`) VALUES
(1, 'esteban', 'freddypadilla190@gmail.com', NULL, '1234', NULL, NULL, NULL, 55123),
(2, 'esteban', 'estebanfenixx@gmail.com', NULL, '$2y$10$zExl5LaruDPemiJk1H8kf.L.0ctEfYlwlV3IAINvmya3SrGWF99YW', NULL, '2021-05-16 09:32:36', '2021-05-16 09:32:36', NULL);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
