import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'http://localhost:8080/api', // Your backend URL
  withCredentials: false, // This is the default
  headers: {
    Accept: 'application/json',
    'Content-Type': 'application/json'
  }
});

export default {
    getGames() {
        return apiClient.get('/games');
    },
    getGameById(gameId) {
        return apiClient.get(`/games/${gameId}`);
    },
    createGame(gameData) {
        return apiClient.post('/games', gameData);
    },
        deleteGame(id) {
        return apiClient.delete(`/games/${id}`);
    }
}