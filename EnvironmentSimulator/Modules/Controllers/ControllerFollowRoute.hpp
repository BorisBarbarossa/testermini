/*
 * esmini - Environment Simulator Minimalistic
 * https://github.com/esmini/esmini
 *
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/.
 *
 * Copyright (c) partners of Simulation Scenarios
 * https://sites.google.com/view/simulationscenarios
 */

#pragma once

#include <string>
#include "Controller.hpp"
#include "pugixml.hpp"
#include "Parameters.hpp"
#include "Entities.hpp"
#include "vehicle.hpp"
#include <queue>

// Enable test mode, which stops the vehicle when reaching a target
// or in case of path not found
#define TEST_MODE

#define CONTROLLER_FOLLOW_ROUTE_TYPE_NAME "FollowRouteController"

namespace scenarioengine
{
	class ScenarioPlayer;
	class ScenarioEngine;

	typedef enum
	{
		MISSED_WAYPOINT,
		PASSED_WAYPOINT,
		WAYPOINT_NOT_REACHED
	} WaypointStatus;

	// base class for controllers
	class ControllerFollowRoute : public Controller
	{
	public:
		ControllerFollowRoute(InitArgs *args);

		static const char *GetTypeNameStatic() { return CONTROLLER_FOLLOW_ROUTE_TYPE_NAME; }
		virtual const char *GetTypeName() { return GetTypeNameStatic(); }
		static const int GetTypeStatic() { return CONTROLLER_TYPE_FOLLOW_ROUTE; }
		virtual int GetType() { return GetTypeStatic(); }

		void Init();
		void Step(double timeStep);
		void Activate(ControlDomains domainMask);
		void ReportKeyEvent(int key, bool down);
		void SetScenarioEngine(ScenarioEngine *scenarioEngine) { scenarioEngine_ = scenarioEngine; };

	private:
		void CreateLaneChange(int lane, double time);
		void CalculateWaypoints();
		bool CanChangeLane(int lane);
		void ChangeLane(double timeStep);
		void UpdateWaypoints(roadmanager::Position vehiclePos, roadmanager::Position nextWaypoint);
		double DistanceBetween(roadmanager::Position p1, roadmanager::Position p2);
		void Deactivate(){ 
			#ifdef TEST_MODE
				object_->SetSpeed(0);
			#endif 
			Controller::Deactivate(); 
		};

		WaypointStatus GetWaypointStatus(roadmanager::Position vehiclePos, roadmanager::Position waypoint);
		ScenarioEngine *scenarioEngine_;
		vehicle::Vehicle vehicle_;
		OSCPrivateAction *laneChangeAction_;
		roadmanager::OpenDrive *odr_;
		std::vector<roadmanager::Position> waypoints_;
		int currentWaypointIndex_;
		int scenarioWaypointIndex_;
		bool changingLane_;
		bool pathCalculated_;
		std::vector<roadmanager::Position> allWaypoints_;
		double laneChangeTime_ = 5;
		double minDistForCollision_ = 10;
	};

	Controller *InstantiateControllerFollowRoute(void *args);
}