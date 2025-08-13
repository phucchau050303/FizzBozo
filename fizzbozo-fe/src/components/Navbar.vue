<script setup>

</script>

<template>
    <nav class="navbar navbar-expand-lg bg-body-tertiary pt-3 pb-3 ps-lg-3">
        <div class="container-fluid">
            <router-link class="navbar-brand" to="/" >FizzBozo</router-link>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse d-flex justify-content-center" id="navbarSupportedContent">
                <ul class="navbar-nav mx-auto mb-2 mb-lg-0 ">
                    <li class="nav-item">
                        <router-link class="nav-link" aria-current="page" to="/">Home</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/games">Games</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/history">History</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/leaderboard">Leaderboard</router-link>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>

<style scoped>
</style>