<script>
import api from '../services/api.js';
export default {
    name: 'Leaderboard',
    data() {
        return {
            leaderboard: [],
            error: null,
            index: 0,
        };
    },
    async created() {
        await this.fetchLeaderboard();
        for (result of this.leaderboard) {
            console.log(result.playerName, result.score, result.gameDuration, result.date);
        }
    },
    methods: {
        async fetchLeaderboard() {
            this.error = null;
            try {
                this.leaderboard = [];
                const response = await api.getLeaderboard();
                // Handle the proxy response by accessing the $values property
                this.leaderboard = response.data.$values;
            } catch (error) {
                this.error = error.message;
                console.error('Error fetching game leaderboard:', error);
            }
        }
    },
};
</script>

<template>
  <div class="container home-container home-text" style="height:45em;">
    <h1 class="mt-5 text-center">Game Leaderboard</h1>
    <p class="mt-5 text-center">Here you can view the leaderboard of the game.</p>
    <table class="table table-striped mt-4">
      <thead class="thead-dark">
        <tr>
          <th>Player Name</th>
          <th>Correct Answers</th>
          <th>Duration (seconds)</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="result in leaderboard" :key="result.playerName + result.date">
          <td>{{ result.playerName }}</td>
          <td>{{ result.score }}</td>
          <td>{{ result.gameDuration }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<style scoped>
</style>