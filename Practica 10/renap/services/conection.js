const mysql = require('mysql2/promise');

const conn = mysql.createPool({
    connectionLimit: 5,
    host: 'us-cdbr-east-03.cleardb.com',
    user: 'b13c14d4853019',
    password: '62629aff',
    database: 'heroku_6194400ee6f8223'
});

module.exports = conn;