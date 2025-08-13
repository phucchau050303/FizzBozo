<script>
import api from '../services/api.js';
export default{
    name: 'GameSession',
    props: {
        playerName: {
            type: String,
            required: true
        },
        duration: {
            type: Number,
            required: true
        },
        gameId: {
            type: [String, Number],
            required: true
        
        } 
    },
    data() {
        return {
            sessionId: null,
            currentNumber: null,
            answer: '',
            gameQuestions: {},
            totalQuestions: 0,
            correctAnswers: 0,
            incorrectAnswers: 0,
            timeLeft: Math.round(this.duration * 60), // Convert minutes to seconds
            timer: null,
            isSessionActive: false,
            formattedTime: '',
            localGameId: null,
            localDuration: null,
            localPlayerName: ''
        }
    },
    async created() {
        this.localGameId = Number(this.gameId);
        this.localDuration = Number(this.duration);
        this.localPlayerName = String(this.playerName);
        this.timeLeft = Math.round(this.localDuration * 60);
        
        if (!this.localPlayerName || !this.localDuration || !this.localGameId) {
            this.$router.push('/');
            return;
        }
        try {
            await this.startSession(); // Make sure this method exists!
        } catch (error) {
            console.error('Failed to start session:', error);
            this.$router.push({
                name: 'Game Management',
                query: { error: 'Failed to start session' }
            });
        }
        
    },
    methods: {
        async startSession() {
            try {
                const response = await api.createGameSession({
                    playerName: this.playerName,
                    durationSeconds: this.timeLeft,
                    gameId: this.gameId
                });
                this.sessionId = response.data.sessionId;
                this.isSessionActive = true;
                this.startTimer();
                this.getNextNumber();
            } catch (error) {
                console.error('Error starting session:', error);
                alert('Failed to start the game session. Please try again.');
            }
        },
        async getNextNumber() {
            try {
                const response = await api.getNextNumber(this.sessionId);
                if (response.data) {
                    this.currentNumber = response.data.number;
                } else {
                    alert('No more numbers available.');
                }
            } catch (error) {
                console.error('Error fetching next number:', error);
                alert('Failed to fetch the next number. Please try again.');
            }
        },

        startTimer() {
            this.timer = setInterval(() => {
                this.timeLeft--;

                const minutes = Math.floor(this.timeLeft / 60);
                const seconds = this.timeLeft % 60;
                this.formattedTime = `${minutes}:${seconds < 10 ? '0' : ''}${seconds}`;

                if (this.timeLeft <=0){
                    this.endSession();
                }
            }, 1000);
        },

        async submitAnswer() {
            if (!this.answer.trim()) {
                alert('Please enter an answer.');
                return;
            }

            try {
                const response = await api.submitAnswer(this.sessionId, {
                    playerAnswer: this.answer,
                    number: this.currentNumber,
                    sessionId: this.sessionId
                });

                if (response.data.isCorrect === true) {
                    this.correctAnswers++;
                } else {
                    this.incorrectAnswers++;
                }
                
                this.totalQuestions++;
                this.answer = ''; // Clear the input field
                this.getNextNumber(); // Fetch the next number
            } catch (error) {
                console.error('Error submitting answer:', error);
                alert('Failed to submit the answer. Please try again.');
            }
        },
        endSession() {
            clearInterval(this.timer);
            this.isSessionActive = false;
            api.createSessionResults(this.sessionId);
            alert('Time is up! Your session has ended.');
            // Optionally, you can redirect the user or show a summary of their performance
            this.$router.push({
                name: 'Game Management',
                query: { error: 'Failed to start session' }
            });
        },
    },
    beforeUnmount() {
        clearInterval(this.timer);
    }
}
</script>

<template>
  <div class="container home-text mt-5">
        <h1 class="text-center mt-5 rounded ">Game Session</h1>
        <div class = "d-flex justify-content-end home-text">
            <p clas=""> 
                Session Id: {{sessionId}}
            </p>
        </div>
        <div class = "d-flex justify-content-end ">
            <p>
                Player Name: {{this.playerName}}
            </p>
        </div>
        <form @submit.prevent="submitAnswer">
            <div class = "row mt-4">
                <div class = "col-md-9 ">
                    <div class="row border rounded p-4 mb-2 me-1 ">
                        <h2 class="text-center mt-2 rounded"> Number to answer</h2>
                        <h1 class="text-center mt-2 rounded question-area text-danger"> {{currentNumber}}</h1>
                    </div>
                    <div class ="row border rounded p-4 mt-2 me-1">
                        <label class="form-label">Answer: </label>
                        <input 
                            v-model= "answer" 
                            type="text" 
                            class="form-control" 
                            placeholder="Enter your answer here" 
                            :disabled="!isSessionActive"></input>
                    </div>

                </div>
                <div class = "col-md-3 border rounded p-4 text-center">
                    <h3 class="text-center mt-4 rounded">Questions Answered</h3>
                    <h4 class = "mb-4">{{ totalQuestions }}</h4>
                    <h3 class="text-center mt-4 rounded">Correct</h3>
                    <h4 class = "mb-4">{{ correctAnswers }}</h4>
                    <h3 class="text-center mt-4 rounded">Incorrect</h3>
                    <h4 class = "mb-4">{{ incorrectAnswers }}</h4>
                    <h3 class="text-center mt-4 rounded">Time Left</h3>
                    <h4 class = "mb-4">{{formattedTime}}</h4>
                </div>
            </div>
            <div class = "d-flex justify-content-center mt-4">
                <button type="submit" class="btn btn-primary btn-lg" :disabled="!isSessionActive || !answer.trim()">Submit Answer</button>
            </div>
        </form>
  </div>
</template>

<style scoped>
.question-area {
    font-size: 10rem;
}

.form-item-card {
  box-shadow: 0 4px 6px rgba(0,0,0,0.1);
}
</style>