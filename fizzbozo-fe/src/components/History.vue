<script>
import api from '../services/api.js';
export default {
    name: 'History',
    data() {
        return {
            history: [],
            error: null,
            playerName: ''
        };
    },
    methods: {
        async fetchHistory() {
            this.loading = true;
            this.error = null;
            try {
                this.history = [];
                const response = await api.getHistory(this.playerName);
                // Handle the proxy response by accessing the $values property
                this.history = response.$values || response.data.$values || response.data;
            } catch (error) {
                this.error = error.message;
                console.error('Error fetching game history:', error);
            }
        }
    },
};
</script>

<template>
    <div class="container home-container home-text ">
        <h1 class="mt-5 text-center">Game History</h1>
        <p class = "mt-5 text-center">Here you can view your past game sessions and their details.</p>
        <form @submit.prevent="fetchHistory" class=" mt-4">
            <label class = "form-label d-flex justify-content-center mb-3">Enter your name to see history:</label>
            <input 
                type="text" 
                v-model="playerName" 
                class="form-control mw-30" 
                placeholder="Enter Your Name" 
                style = "width: 300px; margin: auto;"
                required>
            </input>
            <div class ="d-flex justify-content-center mt-3">
                <button class="btn btn-bd-primary btn-lg text-center mt-3">Load History</button>
            </div>
        </form>
        <div v-if="error" class="alert alert-danger mt-4">
            {{ error }}
            <button @click="fetchHistory" class="btn btn-sm btn-link">Retry</button>
        </div>
        <div v-if="history.length > 0" class="mt-5">
            <h2 class="text-center mb-4">Your Game History</h2>
            <div class = "mt-4 border rounded p-4 form-item-card" 
                v-for="result in history" :key="result.id">
                    <h3>Player Name: {{ result.gameSession.playerName }}</h3>
                    <p>Session Id: {{ result.sessionId }}</p>
                    <p>Total Answers: {{ result.totalAnswers }}</p>
                    <p>Correct Answers: {{ result.correctAnswers }}</p>
                    <p>Duration: {{ result.gameSession.durationSeconds }} seconds</p>
            </div>
        </div>  

    </div>

</template>

<style scoped>
</style>