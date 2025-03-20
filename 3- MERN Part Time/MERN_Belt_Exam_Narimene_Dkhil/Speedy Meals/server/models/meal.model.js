const mongoose = require('mongoose');
const MealSchema = new mongoose.Schema({
    name: {
        type: String,
        required: [true, "{PATH} is required"],
        minlength: [3, "{PATH} must be at least 3 chars"],
        maxlength: [20, "{PATH} must be at most 20 chars"]
    },
    minutes: {
        type: Number,
        required: [true, "{PATH} is required"],
        min: [2, "{PATH} must be at least 2 minutes"],
        max: [240, "{PATH} must be at most 240 minutes"]
    },
    directions: {
        type: String,
        required: [true, "{PATH} is required"],
        minlength: [10, "{PATH} must be at least 10 chars"]
    },
    ingredientOne: {
        type: String,
    },
    ingredientTwo: {
        type: String,
    },
    ingredientThree: {
        type: String,
    }
}, { timestamps: true });

module.exports.Meal = mongoose.model('Meal', MealSchema);