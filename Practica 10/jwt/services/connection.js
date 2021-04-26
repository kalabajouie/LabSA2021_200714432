const mysql = require('mysql2/promise');

const conn = mysql.createPool({
    connectionLimit: 5,
    host: process.env.HOST,
    user: process.env.USERNAME,
    password: process.env.PASSWORD,
    database: process.env.DBNAME
});

module.exports = conn;