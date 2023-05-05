CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

ALTER TABLE accounts
ADD
    COLUMN coverImg VARCHAR(255) NOT NULL DEFAULT 'https://www.tclf.org/sites/default/files/thumbnails/image/YosemiteFalls_signature_Wikimedia_BorisD_2006.jpg';

CREATE TABLE
    keeps(
        id INT UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,
        creatorId VARCHAR(80) NOT NULL,
        name VARCHAR(100) NOT NULL,
        description VARCHAR(500) NOT NULL,
        img VARCHAR(255) NOT NULL,
        views INT UNSIGNED NOT NULL DEFAULT 0,
        Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) DEFAULT CHARSET utf8mb4 COMMENT 'keeps';

DROP TABLE vaultkeeps;

DROP TABLE vaults;

DROP TABLE keeps;

CREATE TABLE
    vaults(
        id INT UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,
        creatorId VARCHAR(80) NOT NULL,
        name VARCHAR(100) NOT NULL,
        description VARCHAR(500) NOT NULL,
        img VARCHAR(255) NOT NULL,
        isPrivate BOOLEAN NOT NULL DEFAULT false,
        Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8mb4 comment 'vaults';

CREATE TABLE
    vaultkeeps(
        id INT UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,
        creatorId VARCHAR(80) NOT NULL,
        vaultId INT UNSIGNED NOT NULL,
        keepId INT UNSIGNED NOT NULL,
        Foreign Key (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
        Foreign Key (keepId) REFERENCES keeps(id) ON DELETE CASCADE,
        Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
        UNIQUE(vaultId, keepId)
    ) DEFAULT charset utf8mb4 COMMENT 'm2m betwen keeps and values';