-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 03 Maj 2019, 22:43
-- Wersja serwera: 10.1.37-MariaDB
-- Wersja PHP: 7.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `minichat`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `messages`
--

CREATE TABLE `messages` (
  `message_id` int(5) NOT NULL,
  `user_id` int(5) NOT NULL,
  `reciver_id` int(5) DEFAULT NULL,
  `message_date` date NOT NULL,
  `message_time` time NOT NULL,
  `message` varchar(255) COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `messages`
--

INSERT INTO `messages` (`message_id`, `user_id`, `reciver_id`, `message_date`, `message_time`, `message`) VALUES
(1, 1, NULL, '2019-05-03', '09:05:00', 'witam!'),
(3, 1, NULL, '2019-05-03', '20:40:51', 'adsada'),
(4, 2, NULL, '2019-05-03', '20:41:21', 'Hellow!'),
(5, 1, NULL, '2019-05-03', '22:28:37', 'witam'),
(6, 1, NULL, '2019-05-03', '22:28:43', 'asdasd'),
(7, 2, NULL, '2019-05-03', '22:31:29', 'Co tam?'),
(8, 1, NULL, '2019-05-03', '22:34:09', 'hejo!'),
(9, 1, NULL, '2019-05-03', '22:34:20', 'no siema'),
(13, 2, NULL, '2019-05-03', '22:40:40', 'helo'),
(14, 2, NULL, '2019-05-03', '22:40:54', 'dasdsadadssssssssssssssssssssssssssssssssssssssssssssssssssss'),
(15, 2, NULL, '2019-05-03', '22:40:59', 'sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `user_id` int(5) NOT NULL,
  `user_nickname` varchar(25) COLLATE utf8_polish_ci NOT NULL,
  `user_password` varchar(25) COLLATE utf8_polish_ci NOT NULL,
  `user_email` varchar(40) COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`user_id`, `user_nickname`, `user_password`, `user_email`) VALUES
(1, 'Nickname', 'Password', 'Nick.pass@wp.pl'),
(2, 'admin', 'admin', 'admin@wp.pl');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `messages`
--
ALTER TABLE `messages`
  ADD PRIMARY KEY (`message_id`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `reciver_id` (`reciver_id`);

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `user_nickname` (`user_nickname`),
  ADD UNIQUE KEY `user_email` (`user_email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `messages`
--
ALTER TABLE `messages`
  MODIFY `message_id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT dla tabeli `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `messages`
--
ALTER TABLE `messages`
  ADD CONSTRAINT `messages_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`),
  ADD CONSTRAINT `messages_ibfk_2` FOREIGN KEY (`reciver_id`) REFERENCES `users` (`user_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
