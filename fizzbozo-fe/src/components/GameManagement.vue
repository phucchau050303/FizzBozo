<script>
import api from '../services/api.js';
export default {
  name: 'GameManagement',
  data() {
    return {
      games: [], // This will hold the list of games
      loading: false,
      error : null
    };
  },
  async created() {
    await this.fetchGames();
      console.log(this.games);
  },
  methods: {
    async fetchGames() {
        this.loading = true;
        this.error = null;
        try {
            const response = await api.getGames();
            // Handle the proxy response by accessing the $values property
            this.games = response.$values || response.data.$values || response.data;
        } catch (error) {
            this.error = error.message;
            console.error('Error fetching games:', error);
        } finally {
            this.loading = false;
        }
    },
    async deleteGame(gameId) {
        if (confirm('Are you sure you want to delete this game?')) {
          try{
            await api.deleteGame(gameId);
            this.games = this.games.filter(game => game.id !== gameId);
            this.fetchGames(); // Refresh the game list after deletion
          } catch (error) {
            console.error('Error deleting game:', error);
            alert('Failed to delete the game. Please try again.');
          }
        }
    },
  }
}

</script>

<template>
    <div class = "container home-container">
        <div>
            <h1 class="text-center mt-5">Game Management</h1>
            <hr></hr>

            <!-- Loading state -->
            <div v-if="loading" class="text-center mt-5">
                <div class="spinner-border text-primary" role="status">
                <span class="visually-hidden">Loading...</span>
                </div>
            </div>

            <!-- Error state -->
            <div v-if="error" class="alert alert-danger mt-4">
                {{ error }}
                <button @click="fetchGames" class="btn btn-sm btn-link">Retry</button>
            </div>

            <div class = "row mt-4">

                <router-link to="/games/create" class="col-md-4">
                    <div class="card fizzbozo-card">
                        <div class="card-body d-flex align-items-center justify-content-center">
                            <svg xmlns="http://www.w3.org/2000/svg" width="50" height="50" fill="currentColor" class="bi bi-plus" viewBox="0 0 16 16">
                                <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4"/>
                            </svg>
                        </div>
                    </div>
                </router-link>
                <div v-for="game in games" :key="game.id" class="col-md-4 mb-4">
                    <div class="card fizzbozo-card fizzbozo-card-content" style = "background-color: #fffefe;" @click="handleClick" >
                        <div class="card-body text-center">
                            <h4 class="card-title  mt-2 mb-4">{{ game.name }}</h4>
                            <h5 class="card-text">Created by</h5>
                            <p>{{ game.author }}</p>
                            <h5 class="card-text">Number of Rules</h5>
                            <p>{{ game.rulesCount }}</p>
                            <h5 class="card-text">Number Range</h5>
                            <p>{{ game.minNumber }}-{{ game.maxNumber }}</p>
                            <div class = "d-flex justify-content-between align-items-center">
                                <router-link 
                                :to="`/`" 
                                class="btn btn-card"
                                style="border-right: 1px solid #e0e0e0; border-radius: 10px 0px 0px 10px;"
                                >
                                Play
                                </router-link>
                                <button 
                                class="btn btn-card" 
                                style="border-left: 1px solid #e0e0e0; border-radius: 0px 10px 10px 0px; color: red"
                                @click.stop="deleteGame(game.id)"
                                >
                                Delete
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>

    </div>
</template>

<style scoped>
.fizzbozo-card {
  width: 250px; /* Adjust width as needed */
  height: 350px; /* Adjust height as needed */
  background-color: #f1f1f1; /* Light grey color */
  border: 1px solid #e0e0e0; /* Optional: subtle border */
  border-radius: 10px;
  cursor: pointer;
  box-shadow: 0 4px 6px rgba(0,0,0,0.1);
  transition: transform 0.2s, box-shadow 0.2s;
}

.fizzbozo-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 6px 12px rgba(0,0,0,0.15);
}

.fizzbozo-card .card-body {
  height: 100%;
}

.fizzbozo-card svg {
  color: #999; /* Grey color for the plus icon */
}

.fizzbozo-card-content{
    font-size: 1.1rem;
    font-weight: 400;
    color: #5C5C5C;
}

.fizzbozo-card-content h4, h5{
    color: #5A7FB7;

}

.btn-card {
    width: 100%;
    color: #5A7FB7;
    font-size: 1.2rem;
    font-weight: 500;

}
</style>