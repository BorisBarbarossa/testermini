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

#define CONTROLLER_FOLLOW_ROUTE_TYPE_NAME "FollowRouteController"

namespace scenarioengine
{
	class ScenarioPlayer;
	class ScenarioEngine;

	typedef enum
	{
		SHORTEST,
		FASTEST,
		MIN_INTERSECTIONS
	} RouteStrategy;

	struct compare
	{
	public:
		bool operator()(roadmanager::RoadPath::PathNode *a, roadmanager::RoadPath::PathNode *b) // overloading both operators
		{
			return a->dist > b->dist;
		}
	};

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
		std::vector<roadmanager::RoadPath::PathNode *> CalculatePath(RouteStrategy routeStrategy);
		void ChangeLane(int lane, double time);
		roadmanager::RoadPath::PathNode *CreateTargetNode(roadmanager::RoadPath::PathNode *currentNode, roadmanager::Road *nextRoad, RouteStrategy routeStrategy);
		void UpdateDistanceVector(std::vector<roadmanager::RoadPath::PathNode *> nextNodes);
		bool TargetLaneIsInDrivingDirection(roadmanager::RoadPath::PathNode *pNode, roadmanager::Road *nextRoad);
		std::vector<roadmanager::RoadPath::PathNode *> GetNextNodes(roadmanager::Road *nextRoad, roadmanager::RoadPath::PathNode *srcNode, RouteStrategy routeStrategy);
		std::vector<int> GetConnectingLanes(roadmanager::RoadPath::PathNode *srcNode, roadmanager::Road *nextRoad);
		bool FindGoal(roadmanager::OpenDrive *odr, RouteStrategy routeStrategy);
		double CalcAverageSpeed(roadmanager::Road *road);
		template <class Q>
		void clearQueue(Q &q)
		{
			q = Q();
		}

		vehicle::Vehicle vehicle_;
		ScenarioEngine *scenarioEngine_;
		std::vector<OSCPrivateAction *> actions_;
		std::priority_queue<roadmanager::RoadPath::PathNode *, std::vector<roadmanager::RoadPath::PathNode *>, compare> unvisited_;
		std::vector<roadmanager::RoadPath::PathNode *> visited_;
		std::vector<roadmanager::RoadPath::PathNode *> distance_;
		roadmanager::Road *targetRoad_;
		roadmanager::Position targetWaypoint_;
	};

	Controller *InstantiateControllerFollowRoute(void *args);
}