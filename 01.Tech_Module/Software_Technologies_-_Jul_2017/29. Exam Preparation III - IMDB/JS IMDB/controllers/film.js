const Film = require('../models/Film');

module.exports = {
	index: (req, res) => {
        //TODO: Implement me ...
        Film.find({}).then(films => {
            res.render('film/index', {'films': films});
        });
	},
	createGet: (req, res) => {
        //TODO: Implement me ...
        res.render('film/create');
	},
	createPost: (req, res) => {
        //TODO: Implement me ...
		let filmArgs = req.body;

		Film.create(filmArgs).then(film => {
			res.redirect('/');
		});
	},
	editGet: (req, res) => {
        //TODO: Implement me ...
		let filmId = req.params.id;

		Film.findById(filmId).then(film => {
			res.render('film/edit', film);
		});
	},
	editPost: (req, res) => {
        //TODO: Implement me ...
		let filmId = req.params.id;
		let filmArgs = req.body;

		Film.findByIdAndUpdate(filmId, filmArgs).then(film => {
			res.redirect('/');
		});
	},
	deleteGet: (req, res) => {
        //TODO: Implement me ...
        let filmId = req.params.id;

        Film.findById(filmId).then(film => {
            res.render('film/delete', film);
        });
	},
	deletePost: (req, res) => {
        //TODO: Implement me ...
        let filmId = req.params.id;

        Film.findByIdAndRemove(filmId).then(film => {
            res.redirect('/');
        });
	}
};