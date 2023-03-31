CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(500) COMMENT 'User Picture',
  coverImg VARCHAR(500) COMMENT 'User Cover Image'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS keeps(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY COMMENT 'Keep Id',
  creatorId VARCHAR(255) NOT NULL COMMENT 'Keep Creator Id',
  name VARCHAR(50) NOT NULL COMMENT 'Keep Name',
  description VARCHAR(300) NOT NULL COMMENT 'Keep Description',
  img VARCHAR(500) NOT NULL COMMENT 'Keep ImgUrl',
  views INT NOT NULL DEFAULT 0 COMMENT 'Total Keep Views',
  kept INT NOT NULL DEFAULT 0 COMMENT 'Number of Vaults Where Keep Exists',

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

DROP TABLE IF EXISTS keeps;
