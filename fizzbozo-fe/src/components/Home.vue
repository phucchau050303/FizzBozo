<script setup>
</script>

<template>
    <div class = 'container home-container'>
        <h1 class="text-center mt-5">FizzBozo</h1>
        <p class="text-center home-text">New way to enjoy FizzBuzz game</p>
        <p class="text-center home-text">Create, Mange or Play by the way you like</p>
        <p class="text-center home-text">Unlimited Experience</p>
        <div class = "row mt-4">
            <div class="d-flex justify-content-center align-items-center flex-column">
                <button class="btn btn-bd-primary btn-lg mb-3">Play Now</button>
            </div>
        </div>
        <p class="text-center home-text mt-4">Got other things in mind? Checkout these options</p>
            <div class="container mt-5">
        <div class="row">
            <div class="col-md-4 text-center"> 
                <button class="btn btn-bd-primary-1 btn-lg mb-3">View <br> History</button>
            </div>
            <div class="col-md-4 text-center">
                <router-link to ="/games/create">
                    <button class="btn btn-bd-primary-2 btn-lg mb-3">Create <br> Games</button>
                </router-link>
                
            </div>
            <div class="col-md-4 text-center">
                <button class="btn btn-bd-primary-3 btn-lg mb-3">Leaderboard</button>
            </div>
        </div>
    </div>
    </div>


</template>

<style scoped>
</style>