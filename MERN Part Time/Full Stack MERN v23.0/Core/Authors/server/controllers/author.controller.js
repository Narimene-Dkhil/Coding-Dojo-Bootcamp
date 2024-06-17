const { Author } = require('../models/author.model');

module.exports.create = (request, response) => {
    Author.create(request.body)
        .then(object => response.json(object))
        .catch(err => response.status(400).json(err))
}

module.exports.getAll = (request, response) => {
    Author.find({})
        .then(objects => response.json(objects))
        .catch(err => response.status(400).json(err))
}

module.exports.getOne = (request, response) => {
    Author.findOne({ _id: request.params.id })
        .then(object => response.json(object))
        .catch(err => response.status(400).json(err))
}

module.exports.update = (request, response) => {
    Author.findOneAndUpdate({ _id: request.params.id }, request.body, { new: true, runValidators: true })
        .then(updated => response.json(updated))
        .catch(err => response.status(400).json(err))
}

module.exports.delete = (request, response) => {
    Author.deleteOne({ _id: request.params.id })
        .then(deleteConfirmation => response.json(deleteConfirmation))
        .catch(err => response.status(400).json(err))
}