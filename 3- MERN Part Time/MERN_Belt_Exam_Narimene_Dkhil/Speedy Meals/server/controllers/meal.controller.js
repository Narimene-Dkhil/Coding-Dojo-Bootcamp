const { Meal } = require('../models/meal.model');

module.exports.create = (request, response) => {
    Meal.create(request.body)
        .then(object => response.json(object))
        .catch(err => response.status(400).json(err))
}

module.exports.getAll = (request, response) => {
    Meal.find({})
        .then(objects => response.json(objects))
        .catch(err => response.status(400).json(err))
}

module.exports.getOne = (request, response) => {
    Meal.findOne({ _id: request.params.id })
        .then(object => response.json(object))
        .catch(err => response.status(400).json(err))
}

module.exports.update = (request, response) => {
    Meal.findOneAndUpdate({ _id: request.params.id }, request.body, { new: true, runValidators: true })
        .then(updated => response.json(updated))
        .catch(err => response.status(400).json(err))
}

module.exports.delete = (request, response) => {
    Meal.deleteOne({ _id: request.params.id })
        .then(deleteConfirmation => response.json(deleteConfirmation))
        .catch(err => response.status(400).json(err))
}