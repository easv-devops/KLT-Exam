CREATE TABLE Addresses (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(70) NOT NULL,
    "StreetnameAndNumber" VARCHAR(50) NOT NULL,
    "Zip" VARCHAR(10) NOT NULL,
    "City" VARCHAR(30) NOT NULL
);
