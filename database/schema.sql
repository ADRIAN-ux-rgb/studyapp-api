-- =========================
-- BANCO DE DADOS
-- =========================
CREATE DATABASE IF NOT EXISTS app_estudos;
USE app_estudos;

-- =========================
-- TABELA USERS
-- =========================
CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(150),
    role_id INT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- =========================
-- TABELA SUBJECTS
-- =========================
CREATE TABLE subjects (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(150) NOT NULL
);

-- =========================
-- TABELA CONTENTS
-- =========================
CREATE TABLE contents (
    id INT AUTO_INCREMENT PRIMARY KEY,
    subject_id INT,
    title VARCHAR(150) NOT NULL,
    content_type VARCHAR(50),
    url TEXT,
    estimated_time_minutes INT,
    FOREIGN KEY (subject_id) REFERENCES subjects(id)
);

-- =========================
-- TABELA STUDY_SESSIONS
-- =========================
CREATE TABLE study_sessions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    content_id INT,
    study_date DATE NOT NULL,
    minutes_studied INT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (content_id) REFERENCES contents(id)
);

-- =========================
-- TABELA GOALS
-- =========================
CREATE TABLE goals (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    subject_id INT,
    target_minutes INT,
    deadline DATE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (subject_id) REFERENCES subjects(id)
);
