﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FirmaBudowlana.Core.DTO;
using FirmaBudowlana.Core.Models;
using FirmaBudowlana.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirmaBudowlana.Api.Controllers
{
    [Authorize]
    public class AddController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IWorkerRepository _workerRepository;
        private readonly ITeamRepository _teamRepository;

        public AddController(IMapper mapper, IWorkerRepository workerRepository, ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _workerRepository = workerRepository;
            _teamRepository = teamRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Worker([FromBody]WorkerDTO workerDTO)
        {
           var worker =_mapper.Map<Worker>(workerDTO);
           worker.WorkerID = Guid.NewGuid();
           await _workerRepository.AddAsync(worker);
           return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Team()
        {
           var teams = await _teamRepository.GetAllAsync();

            return Ok(teams);
        }

        [HttpPost]
        public async Task<IActionResult> Team([FromBody] TeamDTO teamDTO)
        {
            var team = _mapper.Map<Team>(teamDTO);
            team.WorkersTeams = new List<WorkerTeam>();
            team.TeamID = Guid.NewGuid();

            foreach (var worker in teamDTO.Workers)
            {
                team.WorkersTeams.Add(
                    new WorkerTeam()
                    {
                        Team = team,
                        Worker = worker,
                        TeamID= team.TeamID,
                        WorkerID = worker.WorkerID
                    }
              );
            }

            await _teamRepository.AddAsync(team);

            return Ok();
        }


    }
}