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
    },
    createGameSession(sessionData) {
        return apiClient.post(`/sessions`, sessionData);
    },
    getNextNumber(sessionId){
        return apiClient.get(`/sessions`, { params: { sessionId } });
    },
    submitAnswer(sessionId, answerData) {
    return apiClient.post(`/sessions/answer`, answerData, { params: { sessionId } });
    },
    createSessionResults(sessionId) {
        return apiClient.post(`/results`,null, { params: { sessionId } });
    },
    getHistory(playerName) {
        return apiClient.get('/results/name', { params: { playerName } });
    },
    getLeaderboard() {
        return apiClient.get('/results/leaderboard');
    }
}