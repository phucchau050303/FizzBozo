<script>
import api from '../services/api.js';
export default {
  name: 'GameCreate',
  data() {
    return {
      newGame: {
        name: '',
        author: '',
        minNumber: null,
        maxNumber: null,
        rules: [
        { dividedBy: null, word: '' },
        ],
      },
      isSubmitting: false
    }
  },
  methods: {
    addRule() {
      this.newGame.rules.push({ dividedBy: null, word: '' });
    },
    removeRule(index) {
      if (this.newGame.rules.length > 1) {
        this.newGame.rules.splice(index, 1);
      }
    },
    async createGame(event) {
      event.preventDefault(); // Prevent default form submission
      
      // Basic validation
      if (!this.validateForm()) return;
      
      this.isSubmitting = true;

      try {
        const response = await api.createGame(this.newGame);
        if (response.status === 201) {
          this.successMessage = 'Game created successfully! Redirecting...';;

          this.newGame = {
            name: '',
            author: '',
            minNumber: null,
            maxNumber: null,
            rules: [
            { dividedBy: null, word: '' },
            ],
          }
          this.isSubmitting = false;

          this.$router.push('/games');
        }
      } catch (error) {
        console.error('Error creating game:', error);
        alert('An error occurred while creating the game. Please try again.');
      }
    },
    validateForm() {
      // Check required fields
      if (!this.newGame.name.trim()) {
        alert('Please enter a game name');
        return false;
      }
      
      // Check number range validity
      if (this.newGame.minNumber >= this.newGame.maxNumber) {
        alert('Maximum number must be greater than minimum number');
        return false;
      }
      
      // Check rules validity
      for (const rule of this.newGame.rules) {
        if (!rule.dividedBy || !rule.word.trim()) {
          alert('Please fill in all rule fields');
          return false;
        }
      }
      
      return true;
    }
  },
}
</script>

<template>
  <div class="container">
    <h1 class="text-center mt-5 rounded">Create New Game</h1>
    <form @submit.prevent="createGame" class="mt-4">
      <div class = "mt-4 border rounded p-4 form-item-card">
        <label for="gameName" class="form-label h4">Game Name</label>
        <input v-model="newGame.name" type="text" class="form-control" id="gameName" placeholder="Enter game name" required>
      </div>

      <div class = "mt-4 border rounded p-4 form-item-card">
        <label for="author" class="form-label h4">Author</label>
        <input v-model="newGame.author" type="text" class="form-control" id="author" placeholder="Enter your name" required>
      </div>

      <div class = "mt-4 border rounded p-4 form-item-card">
        <h4>Number Range</h4>
        <div class="d-flex justify-content-between">
          <div class="flex-fill me-2">
            <input v-model="newGame.minNumber" type="number" class="form-control" id="minNum" placeholder="Enter min number" required>
          </div>
          <div class="flex-fill me-2">
            <input v-model="newGame.maxNumber" type="number" class="form-control" id="maxNum" placeholder="Enter max number" required>
          </div>
        </div>
      </div>

              
      <div v-for = "(rule, index) in newGame.rules" :key="index" class = "mt-4 border rounded p-4 form-item-card">
        <div class="d-flex justify-content-between align-items-center mb-2">
          <h4>Rule {{index + 1}}</h4>
          <button v-if="newGame.rules.length > 1" @click.prevent="removeRule(index)" type="button" class="btn btn-danger btn-sm">
            Remove
          </button>
        </div>
        <div class="d-flex justify-content-between lign-items-center mb-2">
          <div class="flex-fill me-2">
            <label class="form-label">If number is divided by:</label>
            <input type="number" class="form-control" v-model="rule.dividedBy" placeholder="Enter number" required>
          </div>
          <div class="flex-fill me-2">
            <label class="form-label">Then answer by this word:</label>
            <input type="text" class="form-control" v-model="rule.word" placeholder="Enter associated word" required>
          </div>
        </div>
      </div>

      <div class="mt-3 mb-4">
        <button @click.prevent="addRule" type="button" class="btn btn-success">
          <i class="bi bi-plus"></i> Add Another Rule
        </button>
      </div>

      <div class ="text-center">
        <button 
          type="submit" 
          class="btn btn-primary"
          :disabled="isSubmitting"
          >
          <span v-if="isSubmitting">
            <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
            Creating...
          </span>
          <span v-else>Create Game</span>
        </button>
      </div>

    </form>
    </hr>
  </div>

</template>

<style scoped>
.form-item-card {
  box-shadow: 0 4px 6px rgba(0,0,0,0.1);
}
</style>