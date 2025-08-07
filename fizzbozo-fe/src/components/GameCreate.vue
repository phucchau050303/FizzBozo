<script>
export default {
  name: 'GameCreate',
  data() {
    return {
      rules: [
        { id: 1, num: null, word: '' }
      ],
      nextRuleId: 2
    }
  },
  methods: {
    addRule() {
      this.rules.push({ id: this.nextRuleId, num: null, word: '' });
      this.nextRuleId++;
    },
    removeRule(id) {
      this.rules = this.rules.filter(rule => rule.id !== id);
      this.nextRuleId--;
    }
  },
}
</script>

<template>
  <div class="container">
    <h1 class="text-center mt-5 rounded">Create New Game</h1>
    <form>
      <div class = "mt-4 border rounded p-4 form-item-card">
        <label for="gameName" class="form-label h4">Game Name</label>
        <input type="text" class="form-control" id="gameName" placeholder="Enter game name" required>
      </div>

      <div class = "mt-4 border rounded p-4 form-item-card">
        <label for="author" class="form-label h4">Author</label>
        <input type="text" class="form-control" id="author" placeholder="Enter your name" required>
      </div>

      <div class = "mt-4 border rounded p-4 form-item-card">
        <h4>Number Range</h4>
        <div class="d-flex justify-content-between">
          <div class="flex-fill me-2">
            <input type="number" class="form-control" id="minNum" placeholder="Enter min number" required>
          </div>
          <div class="flex-fill me-2">
            <input type="number" class="form-control" id="maxNum" placeholder="Enter max number" required>
          </div>
        </div>
      </div>

              
      <div v-for = "rule in rules" :key = "rule.id" class = "mt-4 border rounded p-4 form-item-card">
        <div class="d-flex justify-content-between align-items-center mb-2">
          <h4>Rule {{ rule.id }}</h4>
          <button v-if="rules.length > 1" @click.prevent="removeRule(rule.id)" type="button" class="btn btn-danger btn-sm">
            Remove
          </button>
        </div>
        <div class="d-flex justify-content-between lign-items-center mb-2">
          <div class="flex-fill me-2">
            <label for="'ruleNum_' + rule.id" class="form-label">If number is divided by:</label>
            <input type="number" class="form-control" id="'ruleNum_' + rule.id" v-model="rule.num" placeholder="Enter number" required>
          </div>
          <div class="flex-fill me-2">
            <label for="'ruleWord_' + rule.id" class="form-label">Then answer by this word:</label>
            <input type="text" class="form-control" id="'ruleWord_' + rule.id" v-model="rule.word" placeholder="Enter associated word" required>
          </div>
        </div>
      </div>

      <div class="mt-3 mb-4">
        <button @click.prevent="addRule" type="button" class="btn btn-success">
          <i class="bi bi-plus"></i> Add Another Rule
        </button>
      </div>

      <div class ="text-center">
        <button type="submit" class="btn btn-primary">Create Game</button>
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