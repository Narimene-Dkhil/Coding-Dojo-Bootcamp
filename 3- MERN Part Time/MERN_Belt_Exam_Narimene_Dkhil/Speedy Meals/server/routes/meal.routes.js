const MealController = require('../controllers/meal.controller');

module.exports = (app) => {
    app.get('/api/meals', MealController.getAll);
    app.post('/api/meals/new', MealController.create);
    app.get('/api/meals/:id/details', MealController.getOne);
    app.patch('/api/meals/:id/edit', MealController.update);
    app.delete('/api/meals/delete/:id', MealController.delete);
}
