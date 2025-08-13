<script>
import api from '../services/api.js';
export default {
  props: {
    gameId: {
      type: [String, Number],
      required: true
    },
    show: {
      type: Boolean,
      required: true
    }
  },
  data() {
    return {
    game: {},
    error : null,
    rules: {},
    duration: 0,
    };
  },
  watch: {
    show(newVal) {
      if (newVal) {
        this.fetchGameDetails();
      } else {
        this.game = {};
        this.error = null;
        this.rules = {};
      }
    }
  },
  async created() {
    await this.fetchGameDetails();
    this.outputRules();
  },
  methods: {
    closeModal() {
      this.game = {};
      this.error = null;
      this.rules = {};
      this.$emit('close');
    },
    async fetchGameDetails() {
      try {
        const response = await api.getGameById(this.gameId);
        this.game = {
          ...response.data,
        }
        this.rules = response.data.rules?.$values || {};
      } catch (error) {
        console.error('Error fetching game details:', error);
        alert('Failed to load game details. Please try again later.');
      }
    },
  outputRules() {
    // Add check to ensure rules exists and is iterable
    if (!this.rules || !Array.isArray(this.rules)) {
      console.log('Rules is not an array or is empty', this.rules);
      return;
    }
    
    for (const rule of this.rules) {
      console.log(`If number is divided by ${rule.dividedBy}, then answer by "${rule.associatedWord}"`);
    }
  }
  }
};
</script>
<template>
  <div v-if="show" style="display: block;">
    <div class = "model-backdrop fade show">
       <div class="modal fade show" style="display: block;" tabindex="-1">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">{{ game.name }}</h5>
            <button type="button" class="btn-close" @click="closeModal"></button>
          </div>
          <div class="modal-body">
            <h5>Author: {{ game.author }}</h5>
            <h5>Number Range: {{ game.minNumber }} - {{ game.maxNumber }}</h5>
            <h5>Rules:</h5>
            <ul>
              <li v-for="(rule) in rules" >
                If number is divided by {{ rule.dividedBy }}, then answer by "{{ rule.associatedWord }}"
              </li>
            </ul>
            <h5>Created At: {{ new Date(game.createdAt).toLocaleString() }}</h5>
            <form>
              <div class="mb-3">
                <label class="form-label">Game Duration (minute):</label>
                <input class="form-control" type="number" placeholder="Enter duration" v-model="duration"></input>
              </div>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" @click="closeModal">Close</button>
            <button type="button" class="btn btn-primary">Play Game</button>
          </div>
        </div>
      </div>
    </div>
    </div>
  </div>
</template>

<style scoped>
.modal-backdrop {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5); /* Keep this for the backdrop */
  z-index: 1040;
}

.modal {
  position: fixed;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  z-index: 1050;
  background: rgba(0, 0, 0, 0.5); /* Add solid background */
  border-radius: 0.3rem;
  box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15);
}

.modal-content {
  background: white; /* Ensure content has solid background */
  border: none;
}
</style>
