var express = require('express');
var router = express.Router();
const authRoutes = require('./auth');

/* GET home page. */
router.get('/', function(req, res, next) {
  res.json({estado: true, mensaje: 'grupo6'});
});


router.use('/api', authRoutes);

module.exports = router;
