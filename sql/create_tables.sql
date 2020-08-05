CREATE TABLE resident
(
    id INTEGER NOT NULL AUTO_INCREMENT,
    resident_name VARCHAR(30) NOT NULL,
    PRIMARY KEY id
);

CREATE TABLE reconciliation
(
    id INTEGER NOT NULL AUTO_INCREMENT,
    creator_id INTEGER NOT NULL,
    creation_date DATETIME NOT NULL,
    PRIMARY KEY id,
    FOREIGN KEY creator_id REFERENCES resident(id)

)

CREATE TABLE expense_status
(
    id INTEGER NOT NULL,
    status_name VARCHAR(10) NOT NULL,
    PRIMARY KEY id
);

CREATE TABLE expense
(
    id INTEGER NOT NULL AUTO_INCREMENT,
    resident_id INTEGER NOT NULL,
    amount DECIMAL NOT NULL DEFAULT 0,
    transaction_date DATETIME NOT NULL,
    note VARCHAR(50) NOT NULL DEFAULT '',
    status_id NOT NULL DEFAULT 1,
    reconciliation_id NULL,
    PRIMARY KEY id,
    FOREIGN KEY resident_id REFERENCES resident(id),
    FOREIGN KEY status_id REFERENCES expense_status(id),
    FOREIGN KEY reconciliation_id REFERENCES reconciliation(id)
);

CREATE TABLE settlement_status
(
    id INTEGER NOT NULL,
    status_name VARCHAR(10) NOT NULL,
    PRIMARY KEY id
);

CREATE TABLE settlement
(
    id INTEGER NOT NULL AUTO_INCREMENT,
    reconciliation_id INTEGER NOT NULL
    creditor_id INTEGER NOT NULL,
    debtor_id INTEGER NOT NULL,
    amount DECIMAL NOT NULL DEFAULT 0,
    status_id NOT NULL DEFAULT 1,
    PRIMARY KEY id,
    FOREIGN KEY reconciliation_id REFERENCES reconciliation(id),
    FOREIGN KEY creditor_id REFERENCES resident(id),
    FOREIGN KEY debtor_id REFERENCES resident(id),
    FOREIGN KEY status_id REFERENCES settlement_status(id)
);